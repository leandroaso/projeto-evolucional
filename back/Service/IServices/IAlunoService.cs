using Domain.Entities;

namespace Service.IServices
{
    public interface IAlunoService
    {
        public Aluno Insert(Aluno aluno); 
        public Aluno GetBy(string nome); 
    }
}
