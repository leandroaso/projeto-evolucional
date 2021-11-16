using Domain.Entities;

namespace Infrastructure.IRepositories
{
    public interface IAlunoDisciplinaRepository
    {
        public AlunoDisciplina Insert(AlunoDisciplina alunoDisciplina);
        public AlunoDisciplina GetBy(AlunoDisciplina alunoDisciplina);
    }
}
