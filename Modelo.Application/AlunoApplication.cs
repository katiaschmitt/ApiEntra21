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
    }
}
