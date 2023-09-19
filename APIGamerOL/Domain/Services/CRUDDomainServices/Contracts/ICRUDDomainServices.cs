using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.DTO.CRUD;
using System.Linq.Expressions;

namespace APIGamerOL.Domain.Services.CRUDDomainServices.Contracts
{
    public interface ICRUDDomainServices
    {
        public List<Videojuegos> List();
        public List<Videojuegos> PagedList(RequestPagedVideoGameDTO requestPagedVideoGame);
        public Videojuegos FindVideoGame(int idVideoGame);
        public void CreateVideoGame(Videojuegos newvideoGame);
        public void UpdateVideoGame(int id,Videojuegos newvideoGame);
        public void DeleteVideoGame(int id);
    }
}
