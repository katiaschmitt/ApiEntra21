using Modelo.Domain;

namespace Modelo.Application.Interfaces
{
    public interface IAlunoApplication
    {
        Aluno BuscarAluno(int id);
    }
}
