using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastaController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GetDadosPasta(string? pasta)
        {
            var caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "Dados.json");

            if (!System.IO.File.Exists(caminhoArquivo))
            {
                return NotFound("Arquivo Dados.json não encontrado.");
            }

            var json = System.IO.File.ReadAllText(caminhoArquivo);

            return Content(json, "application/json");
        }
    }
}
