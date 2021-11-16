using Domain.Entities;

namespace Infrastructure.IRepositories
{
    public interface IUsuarioRepository
    {
        public Usuario GetBy(Usuario usuario);
    }
}
