using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFirmasAtsProcesosRepository
    {
        Task<IEnumerable<FirmasAtsProcesos>> GetAllAsync();
        Task<FirmasAtsProcesos?> GetByIdAsync(int id);
        Task<FirmasAtsProcesos> AddAsync(FirmasAtsProcesos entity);
        Task UpdateAsync(int id, FirmasAtsProcesos entity);
        Task DeleteAsync(int id);
    }
}
