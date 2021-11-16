namespace Domain.Entities
{
    public class AlunoDisciplina
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public decimal Nota { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
