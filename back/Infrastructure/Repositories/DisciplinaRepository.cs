using Dapper;
using Domain.Entities;
using Infrastructure.IRepositories;

namespace Infrastructure.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {

        private readonly IDapperConnection _dapper;

        public DisciplinaRepository(IDapperConnection dapperConnection)
        {
            _dapper = dapperConnection;
        }

        public Disciplina GetBy(string codigo)
        {
            var query = @"
                SELECT
                    ID,
                    DESCRICAO,
                    CODIGO
                FROM
                    DISCIPLINA
                where
                    CODIGO = @codigo;";

            return _dapper.GetConnection().QuerySingleOrDefault<Disciplina>(query, new { codigo });
        }

        public Disciplina Insert(Disciplina disciplina)
        {
            var query = @"
                INSERT INTO
                    DISCIPLINA (DESCRICAO, CODIGO)
                VALUES
                (@descricao, @codigo);

                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            disciplina.Id = _dapper.GetConnection().QuerySingle<int>(query, disciplina);

            return disciplina;
        }
    }
}
