using Domain.DTOs;
using Domain.Entities;

namespace Service.IServices
{
    public interface IAuthService
    {
        public AcessTokenDto GetToken(Usuario usuario); 
    }
}
