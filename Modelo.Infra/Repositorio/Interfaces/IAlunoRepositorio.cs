using Modelo.Domain;

namespace Modelo.Infra.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno BuscarId(int id);
    }
}
