using Domain.Entities;

namespace Infrastructure.IRepositories
{
    public interface IDisciplinaRepository
    {
        public Disciplina Insert(Disciplina disciplina);
        public Disciplina GetBy(string codigo);
    }
}
