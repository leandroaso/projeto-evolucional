using Dapper;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AlunoDisciplinaRepository : IAlunoDisciplinaRepository
    {
        private readonly IDapperConnection _dapper;

        public AlunoDisciplinaRepository(IDapperConnection dapperConnection)
        {
            _dapper = dapperConnection;
        }

        public AlunoDisciplina GetBy(AlunoDisciplina alunoDisciplina)
        {
            var query = @"
                SELECT
	                ad.ID,
	                ad.ALUNO_ID,
	                ad.DISCIPLINA_ID,
	                ad.NOTA,
	                a.ID,
	                a.NOME,
	                d.ID,
	                d.CODIGO,
	                d.DESCRICAO 
                FROM
	                ALUNO_DISCIPLINA ad 
	                INNER JOIN ALUNO a ON a.ID = ad.ALUNO_ID
	                INNER JOIN DISCIPLINA d ON d.ID = ad.DISCIPLINA_ID 
                WHERE 
	                ad.ALUNO_ID = @alunoId
	                AND ad.DISCIPLINA_ID = @disciplinaId ;
";

            return _dapper.GetConnection().Query(query, (Func<AlunoDisciplina, Aluno, Disciplina, AlunoDisciplina>)
                ((alunoDisciplina, aluno, disciplina) =>
                {
                    return alunoDisciplina;
                }), param: new
                {
                    alunoId = alunoDisciplina.Aluno.Id,
                    disciplinaId = alunoDisciplina.Disciplina.Id
                }).SingleOrDefault();
        }

        public AlunoDisciplina Insert(AlunoDisciplina alunoDisciplina)
        {
            var query = @"
                INSERT INTO
                    ALUNO_DISCIPLINA (ALUNO_ID, DISCIPLINA_ID, NOTA)
                VALUES
                    (@alunoId, @disciplinaId, @nota);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            alunoDisciplina.Id = _dapper.GetConnection().QuerySingle<int>(query, new
            {
                alunoId = alunoDisciplina.Aluno.Id,
                disciplinaId = alunoDisciplina.Disciplina.Id,
                nota = alunoDisciplina.Nota
            });

            return alunoDisciplina;
        }
    }
}
