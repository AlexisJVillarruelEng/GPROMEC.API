using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ITrabajadoresService
    {
        Task<IEnumerable<TrabajadorDTO>> GetAllAsync(bool incluirInactivos = false);
        Task<TrabajadorDTO> GetByIdAsync(int id);
        Task<int> AddAsync(CrearTrabajadorDTO trabajadorDto);
        Task<string> IniciarSesionAsync(InicioSesionDTO inicioSesionDto);
        Task UpdateAsync(CrearTrabajadorDTO trabajadorDto, int id);
        Task DeleteLogicallyAsync(int id);
        Task DeletePermanentlyAsync(int id);
    }
}
