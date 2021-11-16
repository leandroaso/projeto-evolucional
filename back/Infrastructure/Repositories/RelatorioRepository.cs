using Dapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly IDapperConnection _dapper;

        public RelatorioRepository(IDapperConnection dapperConnection)
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

        public IList<RelatorioDto> GetRelatorio()
        {
            var query = @"
              SELECT 
	            a.NOME, 
	            ad1.NOTA as MATEMATICA, 
	            ad2.NOTA as PORTUGUES, 
	            ad3.NOTA as HISTORIA,
	            ad4.NOTA as GEOGRAFICA,
	            ad5.NOTA as INGLES,
	            ad6.NOTA as BIOLOGIA,
	            ad7.NOTA as FILOSOFIA,
	            ad8.NOTA as FISICA,
	            ad9.NOTA as QUIMICA
            FROM ALUNO a 
	            inner join ALUNO_DISCIPLINA ad1 on a.ID = ad1.ALUNO_ID
	            inner join DISCIPLINA d1 on d1.ID = ad1.DISCIPLINA_ID and d1.CODIGO ='MATEMATICA'
	            inner join ALUNO_DISCIPLINA ad2 on a.ID = ad2.ALUNO_ID
	            inner join DISCIPLINA d2 on d2.ID = ad2.DISCIPLINA_ID and d2.CODIGO ='PORTUGUES'	
	            inner join ALUNO_DISCIPLINA ad3 on a.ID = ad3.ALUNO_ID
	            inner join DISCIPLINA d3 on d3.ID = ad3.DISCIPLINA_ID and d3.CODIGO ='HISTORIA'
	            inner join ALUNO_DISCIPLINA ad4 on a.ID = ad4.ALUNO_ID
	            inner join DISCIPLINA d4 on d4.ID = ad4.DISCIPLINA_ID and d4.CODIGO ='GEOGRAFICA'
	            inner join ALUNO_DISCIPLINA ad5 on a.ID = ad5.ALUNO_ID
	            inner join DISCIPLINA d5 on d5.ID = ad5.DISCIPLINA_ID and d5.CODIGO ='INGLES'
                inner join ALUNO_DISCIPLINA ad6 on a.ID = ad6.ALUNO_ID
	            inner join DISCIPLINA d6 on d6.ID = ad6.DISCIPLINA_ID and d6.CODIGO ='BIOLOGIA'
                inner join ALUNO_DISCIPLINA ad7 on a.ID = ad7.ALUNO_ID
	            inner join DISCIPLINA d7 on d7.ID = ad7.DISCIPLINA_ID and d7.CODIGO ='FILOSOFIA'
                inner join ALUNO_DISCIPLINA ad8 on a.ID = ad8.ALUNO_ID
	            inner join DISCIPLINA d8 on d8.ID = ad8.DISCIPLINA_ID and d8.CODIGO ='FISICA'
                inner join ALUNO_DISCIPLINA ad9 on a.ID = ad9.ALUNO_ID
	            inner join DISCIPLINA d9 on d9.ID = ad9.DISCIPLINA_ID and d9.CODIGO ='QUIMICA' ";

            return _dapper.GetConnection()
                .Query<RelatorioDto>(query).ToList();
        }
    }
}
