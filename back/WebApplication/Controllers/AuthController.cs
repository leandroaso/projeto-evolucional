using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("token")]
        public ActionResult<AcessTokenDto> Login([FromBody] Usuario usuario)
        {
            var acessToken = _service.GetToken(usuario);

            if (acessToken == null)
                return NotFound("Usuário ou senha inválidos.");

            return Ok(acessToken);
        }
    }
}
