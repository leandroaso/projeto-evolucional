using Dapper;
using Domain.Entities;
using Infrastructure.IRepositories;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly IDapperConnection _dapper;

        public UsuarioRepository(IDapperConnection dapperConnection)
        {
            _dapper = dapperConnection;
        }

        public Usuario GetBy(Usuario usuario)
        {
            var query = @"
                SELECT
                    ID,
                    LOGIN,
                    SENHA
                FROM
                    USUARIO
                WHERE
                    LOGIN = @login";

            return _dapper.GetConnection()
                .QuerySingleOrDefault<Usuario>(query, usuario);
        }
    }
}
