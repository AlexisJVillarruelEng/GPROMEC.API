using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFormPermisoRepository
    {
        Task<IEnumerable<FormPermisos>> GetAllAsync();
        Task<FormPermisos?> GetByIdAsync(int id);
        Task<FormPermisos> AddAsync(FormPermisos entity);
        Task UpdateAsync(int id, FormPermisos entity);
        Task DeleteAsync(int id);
    }
}