using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace WebApplication.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class EvolucionalController : ControllerBase
    {
        private readonly IEvolucionalService _evolucionalService;

        public EvolucionalController(IEvolucionalService evolucional)
        {
            _evolucionalService = evolucional;
        }

        [HttpGet("carga-dados")]
        public ActionResult GerarCargaDeDados()
        {
            _evolucionalService.GerarCargaDeDados();
            return Ok();
        }

        [HttpGet("relatorio")]
        public IActionResult GeraRelatorio()
        {
            return File(_evolucionalService.GerarRelatorioExcel(), "application/excel");
        }
    }
}
