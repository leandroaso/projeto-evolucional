using Domain.Entities;
using Infrastructure.IRepositories;
using Service.IServices;

namespace Service.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public Aluno GetBy(string nome)
        {
            return _repository.GetBy(nome);
        }

        public Aluno Insert(Aluno aluno)
        {
            return _repository.Insert(aluno);
        }
    }
}
