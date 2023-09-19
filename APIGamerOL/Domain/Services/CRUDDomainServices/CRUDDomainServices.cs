using APIGamerOL.DataAccess.Contexts;
using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.Domain.Services.CRUDDomainServices.Contracts;
using APIGamerOL.DTO.CRUD;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIGamerOL.Domain.Services.CRUDDomainServices
{
    public class CRUDDomainServices:ICRUDDomainServices
    {
        #region Fields
        private readonly CRUDContext _context;
        #endregion
        #region Builder
        public CRUDDomainServices(CRUDContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public List<Videojuegos> List()
        {
            var list = _context.Videojuegos.AsNoTracking().ToList();
            return list;
        }
        public List<Videojuegos> PagedList(RequestPagedVideoGameDTO requestPagedVideoGame)
        {
            var list = _context.Videojuegos.AsNoTracking().Where(x=>x.Nombre == requestPagedVideoGame.NameVideoGame || x.Compañia== requestPagedVideoGame.Company || x.AñoLanzamiento== requestPagedVideoGame.YearOfLaunch)?.ToList();
            return list;
        }
        public Videojuegos FindVideoGame(int idVideoGame)
        {
            var dataVideoGame = _context.Videojuegos.AsNoTracking().FirstOrDefault(x => x.Id == idVideoGame);
            return dataVideoGame;
        }
        public void CreateVideoGame(Videojuegos newvideoGame)
        {
            _context.Videojuegos.Add(newvideoGame);
            _context.SaveChanges();

        }
        public void UpdateVideoGame(int id,Videojuegos newVideoGame)
        {
            _context.Videojuegos.Update(newVideoGame);
            _context.SaveChanges();

        }
        public void DeleteVideoGame(int id)
        {
            var dataVideoGame = _context.Videojuegos.AsNoTracking().Include(x=>x.Calificaciones).FirstOrDefault(x => x.Id == id);
            _context.Videojuegos.Remove(dataVideoGame);
            _context.SaveChanges();

        }

        #endregion
    }
}
