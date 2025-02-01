using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFirmasMatrizIperService
    {
        Task<IEnumerable<FirmasDTO>> GetAllAsync();
        Task<FirmasDTO> GetByIdAsync(int id);
        Task<FirmasDTO> CreateAsync(CrearFirmaDTO firmaDto);
        Task<FirmasDTO> UpdateAsync(int id, ActualizarFirmaDTO firmaDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<FirmasDTO>> ObtenerFirmasPorMatriz(int id_partida);
    }
}
