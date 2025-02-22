using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IFormPermisoService
    {
        Task<IEnumerable<FormPermisosDTO>> GetAllAsync();
        Task<FormPermisosDTO?> GetByIdAsync(int id);
        Task<FormPermisosDTO> AddAsync(FormPermisosDTO dto);
        Task UpdateAsync(int id, FormPermisosDTO dto);
        Task DeleteAsync(int id);
    }
}