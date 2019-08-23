using RDP.ARB.Hunter.Application.Models;
using RDP.ARB.Hunter.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RDP.ARB.Hunter.Controllers
{
    [Route("v1/Ordens")]
    public class OrdensController : Controller
    {
        private IOrdensService _ordensService;
        public OrdensController(IOrdensService ordensService)
        {
            _ordensService = ordensService;
        }

        [Route("{moeda}")]
        [HttpPost]
        public IActionResult OrdensPorMoeda([FromRoute] string moeda, [FromBody] OrdensPorMoedaRequest requestModel)
        {
            var result = _ordensService.ObtemOrdensPorMoeda(requestModel);

            return Ok(result);
        }
    }
}
