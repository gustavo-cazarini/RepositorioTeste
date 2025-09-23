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

        [HttpGet("[action]")]
        public IActionResult GetEventos(string? pasta)
        {
            if (string.IsNullOrEmpty(pasta))
                return BadRequest("Pasta não informada");

            var dados = new
            {
                eventos = new[] {
                    new { pasta = "20232-@-COM", evento = "//Manifestação", data = DateTime.Parse("2025-09-18"), detalhes = "Eventual manifestação acerca da determinação para aguardar mais 30 dias para a entrega do laudo.", encarregado = "Matheus Santos" },
                    new { pasta = "20232-@-COM", evento = "/INTERNO", data = DateTime.Parse("2025-09-17"), detalhes = "09.09.2025 - Solicitei a atualização do cálculo de risco. //Matheus\r\n\r\n10.09.2025 - Relatório devidamente atualizado. // Mirele Santos \r\n\r\n\r\n\r\n\r\nMirele, bom dia.\r\n\r\nPor gentileza, acompanhar o retorno da contadoria e, quando efetivado, atualizar na íntegra o relatório para atualizarmos o cliente do estado atual da demanda.\r\n\r\nAtenciosamente,\r\n\r\nMS", encarregado = "Matheus Santos" },
                    new { pasta = "20232-@-COM", evento = "/PROCESSO PARADO", data = DateTime.Parse("2025-07-30"), detalhes = "Dar baixa informando e verificando, por ex: se há razão de permanecer parado, verificando no site do tribunal; se o nome do Advogado Sócio está saindo na publicação; oportunidade de composição e revisão de prognóstico; atualizar a informação ao cliente; regularidade no cadastro e etc...", encarregado = "Suporte Cliente" },
                    new { pasta = "20232-@-COM", evento = "//Manifestação", data = DateTime.Parse("2025-04-29"), detalhes = "Eventual manifestação acerca da decisão retro. \r\n", encarregado = "Matheus Santos" },
                    new { pasta = "1", evento = "/PRAZO CONTROL. PROTOCOLO", data = DateTime.Parse("2019-10-18"), detalhes = "", encarregado = "BONINI" },
                    new { pasta = "1", evento = "/Prazo Anulado", data = DateTime.Parse("2018-06-07"), detalhes = "\r\nEventual manifestação referente as fls. 117/177 e pagamento no prazo de 15 dias referente as despesas do tratamento médico\r\n\r\nRemarcado do dia 28/05\r\n\r\nRemarcado do dia 05/06\r\n", encarregado = "Luciana Mussa" },
                    new { pasta = "1", evento = "/INFOWEB -and. atual. do escritório para portal", data = DateTime.Parse("2016-12-26"), detalhes = "Sem movimentação", encarregado = "Daniela Benes" },
                    new { pasta = "1", evento = "/INFOWEB -and. atual. do escritório para portal", data = DateTime.Parse("2014-01-14"), detalhes = "Sem movimentação", encarregado = "Daniela Benes" },
                }
            };

            var eventosEncontrados = dados.eventos.Where(ev => ev.pasta.StartsWith(pasta)).ToList();

            return Ok(eventosEncontrados);
        }
    }
}
