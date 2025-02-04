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
        Task<LoginResponseDTO> IniciarSesionAsync(InicioSesionDTO inicioSesionDto);
        Task<bool> UpdateAsync(int id,ActualizarTrabajadorDTO trabajadorDTO);
        Task DeleteLogicallyAsync(int id);
        Task DeletePermanentlyAsync(int id);
    }
}
