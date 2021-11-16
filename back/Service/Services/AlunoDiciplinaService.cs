using Domain.Entities;
using Infrastructure.IRepositories;
using Service.IServices;

namespace Service.Services
{
    public class AlunoDisciplinaService : IAlunoDisciplinaService
    {
        private readonly IAlunoDisciplinaRepository _repository;

        public AlunoDisciplinaService(IAlunoDisciplinaRepository repository)
        {
            _repository = repository;
        }

        public AlunoDisciplina GetBy(AlunoDisciplina alunoDisciplina)
        {
            return _repository.GetBy(alunoDisciplina);
        }

        public AlunoDisciplina Insert(AlunoDisciplina alunoDisciplina)
        {
            return _repository.Insert(alunoDisciplina);
        }
    }
}
