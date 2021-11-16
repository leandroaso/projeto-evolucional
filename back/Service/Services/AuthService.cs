using Domain.DTOs;
using Domain.Entities;
using Domain.Utils;
using Infrastructure.IRepositories;
using Microsoft.Extensions.Configuration;
using Service.IServices;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public AcessTokenDto GetToken(Usuario usuario)
        {
            var user = _repository.GetBy(usuario);

            if (user == null)
                return null;

            if (!MD5Util.VerifyMd5Hash(usuario.Senha, user.Senha))
                return null;

            var token = TokenUtil.GetToken(_configuration["jwt:Secret"], user);

            return new AcessTokenDto { Login = user.Login, Token = token };
        }
    }
}
