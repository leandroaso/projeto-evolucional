using Domain.DTOs;
using System.Collections.Generic;

namespace Infrastructure.IRepositories
{
    public interface IRelatorioRepository
    {
        public IList<RelatorioDto> GetRelatorio();
    }
}
