using Domain.Entities;
using Infrastructure.IRepositories;
using Service.IServices;

namespace Service.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;
        }

        public Disciplina GetBy(string codigo)
        {
            return _repository.GetBy(codigo);
        }

        public Disciplina Insert(Disciplina disciplina)
        {
            return _repository.Insert(disciplina);
        }
    }
}
