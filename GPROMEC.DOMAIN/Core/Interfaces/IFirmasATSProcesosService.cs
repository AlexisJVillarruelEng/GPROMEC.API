using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFirmasAtsProcesosService
    {
        Task<IEnumerable<FirmasAtsProcesosDto>> GetAllAsync();
        Task<FirmasAtsProcesosDto?> GetByIdAsync(int id);
        Task<FirmasAtsProcesosDto> AddAsync(FirmasAtsProcesosDto dto);
        Task UpdateAsync(int id, FirmasAtsProcesosDto dto);
        Task DeleteAsync(int id);
    }
}
