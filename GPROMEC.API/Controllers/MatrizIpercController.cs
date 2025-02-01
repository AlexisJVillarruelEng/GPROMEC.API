using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class MatrizIpercController : ControllerBase
    {
        private readonly IMatrizIpercService _matrizIpercService;

        public MatrizIpercController(IMatrizIpercService matrizIpercService)
        {
            _matrizIpercService = matrizIpercService;
        }

        [HttpGet("{id_partida}")]
        public async Task<IActionResult> ObtenerMatriz(int id_partida)
        {
            var matriz = await _matrizIpercService.ObtenerMatrizPorPartida(id_partida);
            return matriz != null ? Ok(matriz) : NotFound();
        }

        [HttpPut("{id_partida}")]
        public async Task<IActionResult> ActualizarMatriz(int id_partida, [FromBody] MatrizIpercDTO matriz)
        {
            var result = await _matrizIpercService.ActualizarMatriz(matriz);
            return result ? Ok() : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CrearMatriz([FromBody] MatrizIpercDTO matriz)
        {
            var id = await _matrizIpercService.CrearMatriz(matriz);
            return CreatedAtAction(nameof(ObtenerMatriz), new { id_partida = id }, matriz);
        }
    }

}
