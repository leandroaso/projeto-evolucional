using Domain.DTOs;
using Domain.Utils;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;

namespace Domain.Extensions
{
    public static class RelatorioExtension
    {
        public static byte[] ToExcelFile(this IList<RelatorioDto> listaRelatorioDto)
        {
            IWorkbook workbook = ExportUtility.WriteExcelWithNPOI(listaRelatorioDto);
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);

            return stream.ToArray();
        }
    }
}
