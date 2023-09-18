using APIGamerOL.Domain.Entities.SecureEntities;

namespace APIGamerOL.Domain.Services.SecureDomainServices.Contracts
{
    public interface ISecureDomainServices
    {
        public void Insert(Usuario usuario);
        public Usuario Find(string email, string password);
    }
}
