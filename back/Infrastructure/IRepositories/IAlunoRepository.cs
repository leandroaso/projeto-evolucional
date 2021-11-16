using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.IRepositories
{
    public interface IAlunoRepository
    {
        public Aluno Insert(Aluno aluno);
        public Aluno GetBy(string nome);
    }
}
