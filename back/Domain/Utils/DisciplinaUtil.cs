using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Utils
{
    public static class DisciplinaUtil
    {
        public static IList<Disciplina> GetMockDisciplinas()
        {
            return new List<Disciplina>
            {
                new Disciplina
                {
                    Descricao = "Matemática",
                    Codigo = "MATEMATICA"
                },
                new Disciplina
                {
                    Descricao = "Português",
                    Codigo = "PORTUGUES"
                },
                new Disciplina
                {
                    Descricao = "História",
                    Codigo = "HISTORIA"
                },
                new Disciplina
                {
                    Descricao = "Geografica",
                    Codigo = "GEOGRAFICA"
                },
                new Disciplina
                {
                    Descricao = "Inglês",
                    Codigo = "INGLES"
                },
                new Disciplina
                {
                    Descricao = "Biologia",
                    Codigo = "BIOLOGIA"
                },
                new Disciplina
                {
                    Descricao = "Filosofia",
                    Codigo = "FILOSOFIA"
                },
                new Disciplina
                {
                    Descricao = "Física",
                    Codigo = "FISICA"
                },
                new Disciplina
                {
                    Descricao = "Química",
                    Codigo = "QUIMICA"
                }
            };
        }
    }
}
