using APIGamerOL.DataAccess.Contexts;
using APIGamerOL.Domain.Entities.SecureEntities;
using APIGamerOL.Domain.Services.SecureDomainServices.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APIGamerOL.Domain.Services.SecureDomainServices
{
    public class SecureDomainServices:ISecureDomainServices
    {
        #region Fields
        private readonly SecureContext _context;
        #endregion

        #region Builder
        public SecureDomainServices(SecureContext context) 
        { 
            _context = context;
        }
        #endregion

        #region Public Methods
        public void Insert(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
        public Usuario Find(string email, string password) 
        {
            return _context.Usuario.AsNoTracking().FirstOrDefault(x => x.CorreoElectronico == email && x.Contrasena == password);
        }
        #endregion
    }
}
