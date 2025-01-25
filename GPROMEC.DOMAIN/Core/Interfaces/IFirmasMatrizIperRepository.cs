using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFirmasMatrizIperRepository
    {
        Task<IEnumerable<FirmasMatrizIper>> GetAllAsync();
        Task<FirmasMatrizIper> GetByIdAsync(int id);
        Task<int> CreateAsync(FirmasMatrizIper firma);
        Task UpdateAsync(FirmasMatrizIper firma);
        Task DeleteAsync(int id);
    }
}
