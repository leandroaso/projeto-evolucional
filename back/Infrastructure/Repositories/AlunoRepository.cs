using Dapper;
using Domain.Entities;
using Infrastructure.IRepositories;

namespace Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDapperConnection _dapper;

        public AlunoRepository(IDapperConnection dapperConnection)
        {
            _dapper = dapperConnection;
        }

        public Aluno GetBy(string nome)
        {
            var query = @"
                SELECT
                    ID,
                    NOME
                FROM
                    ALUNO
                WHERE
                    NOME = @nome";

            return _dapper.GetConnection()
                .QuerySingleOrDefault<Aluno>(query, new { nome });
        }

        public Aluno Insert(Aluno aluno)
        {
            var query = @"
                INSERT INTO
                    ALUNO (NOME)
                VALUES
                    (@nome);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            aluno.Id = _dapper.GetConnection().QuerySingle<int>(query, aluno);

            return aluno;
        }
    }
}
