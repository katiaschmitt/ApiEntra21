using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interfaces;
using Modelo.Domain;

namespace ApiEntra21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAlunoApplication _alunoApplication;

        public AlunoController(IAlunoApplication alunoApplication)
        {
           _alunoApplication = alunoApplication;      
        }

        [HttpGet("BuscarDadosAluno/{id}")]
        public IActionResult BuscarDadosAluno(int id)
        {
            Retorno<Aluno> retorno = new(null);

            try
            {
                var aluno = _alunoApplication.BuscarAluno(id);

                if(aluno != null)
                {
                    retorno.CarregaRetorno(aluno, true, "Consulta realizada com sucesso", 200);
                }
                else
                {
                    retorno.CarregaRetorno(aluno, false, $"aluno com o id {id} não foi encontrado", 204);
                }

                    return Ok(retorno);

            }
            catch (Exception e)
            {
                retorno.CarregaRetorno(false, e.Message, 400);
                return BadRequest(retorno);
            }

            
        }

        [HttpPost("InserirDadosAluno")]
        public IActionResult InserirDadosAluno([FromBody] Aluno aluno)
        {
            Retorno retorno = new();

            try
            {
               var mensagem = _alunoApplication.InserirAluno(aluno);
                retorno.CarregaRetorno(true, mensagem, 200);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                retorno.CarregaRetorno(false, e.Message, 400);
                return BadRequest();
            }
        }


        [HttpDelete("ExcluirDadosAluno/{id}")]
        public IActionResult ExcluirDadosAluno(int id)
        {
            try
            {
                _alunoApplication.ExcluirAluno(id);
                return Ok("Aluno Excluído com sucesso!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }
    }
}
