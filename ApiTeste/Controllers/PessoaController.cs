using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly Pessoa[] Pessoas =
        {
            new Pessoa { Nome = "Gustavo", Sobrenome = "Cazarini", Idade = 24, DataNascimento = DateTime.Parse("2001/08/02"), LocalTrabalho = "JAB Advogados" },
            new Pessoa { Nome = "Ivan", Sobrenome = "Marques", Idade = 30, DataNascimento = DateTime.Parse("1990/01/01"), LocalTrabalho = "JAB Advogados" },
            new Pessoa { Nome = "Raimundo", Sobrenome = "Silva", Idade = 70, DataNascimento = DateTime.Parse("1955/01/01"), LocalTrabalho = "Google" }
        };

        [HttpGet("[action]")]
        public IEnumerable<Pessoa> GetAll()
        {
            int repeticoes = 100;

            var repetida = Pessoas
                .SelectMany(p => Enumerable.Repeat(p, repeticoes))
                .ToList();


            return repetida.ToArray();
        }

        [HttpGet("[action]")]
        public Pessoa? GetByName(string nome)
        {
            return Pessoas.Where(pessoa => pessoa.Nome == nome).FirstOrDefault();
        }
    }
}
