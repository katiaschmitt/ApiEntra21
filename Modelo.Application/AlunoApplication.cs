using Modelo.Application.Interfaces;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;


namespace Modelo.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public Aluno BuscarAluno(int id)
        {
           return _alunoRepositorio.BuscarId(id);         
        }

        public string InserirAluno(Aluno aluno)
        {
            var mensagem = ValidaAluno(aluno);

            if(mensagem == "")
            {
                _alunoRepositorio.InserirAluno(aluno);
                mensagem = "Aluno Inserido com sucesso";
            }
                              
            return mensagem;
        }

        public void ExcluirAluno(int id)
        {
            _alunoRepositorio.ExcluirAluno(id);
        }

        private string ValidaAluno(Aluno aluno)
        {
            string mensagem = ""; 

            if (!aluno.Nome.Any())
                mensagem = "Não é possível inserir aluno sem nome";

            if (aluno.Nome.Length > 50)
                mensagem = "O nome do aluno deve possuir apenas 50 caracteres.";

            if (aluno.Cep.Length > 14)
                mensagem = "O cep deve possuir apenas 14 caracteres.";

            if(aluno.Idade < 0)
                mensagem = "Informe uma idade válida!";

            return mensagem;    
        }
    }
}
