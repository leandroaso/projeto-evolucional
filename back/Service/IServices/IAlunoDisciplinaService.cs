using Domain.Entities;

namespace Service.IServices
{
    public interface IAlunoDisciplinaService
    {
        public AlunoDisciplina Insert(AlunoDisciplina alunoDisciplina);
        public AlunoDisciplina GetBy(AlunoDisciplina alunoDisciplina);
    }
}
