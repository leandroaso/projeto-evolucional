using Domain.Entities;

namespace Service.IServices
{
    public interface IDisciplinaService
    {
        public Disciplina Insert(Disciplina disciplina);
        public Disciplina GetBy(string codigo);
    }
}
