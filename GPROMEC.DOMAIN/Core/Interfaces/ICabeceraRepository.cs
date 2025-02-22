using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ICabeceraATSRepository
    {
        Task<IEnumerable<CabeceraAts>> GetAllAsync();
        Task<CabeceraAts?> GetByIdAsync(int id);
        Task<CabeceraAts> AddAsync(CabeceraAts entity);
        Task UpdateAsync(int id, CabeceraAts entity);
        Task DeleteAsync(int id);
    }
}
