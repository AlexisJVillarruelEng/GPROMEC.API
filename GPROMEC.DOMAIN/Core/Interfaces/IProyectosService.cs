using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IProyectosService
    {
        Task<IEnumerable<ProyectoDTO>> GetAllAsync(bool incluirInactivos = false); // Obtener proyectos activos/inactivos.
        Task<ProyectoDTO> GetByIdAsync(int id); // Obtener un proyecto por ID.
        Task<int> AddAsync(CrearProyectoDTO proyectoDto); // Insertar un proyecto y devolver el ID.
        Task UpdateAsync(CrearProyectoDTO proyectoDto, int id); // Actualizar un proyecto existente.
        Task DeleteLogicallyAsync(int id); // Eliminar lógicamente un proyecto.
        Task DeletePermanentlyAsync(int id); // Eliminar físicamente un proyecto.
        Task ProbarConexionFirebase();
    }
}
