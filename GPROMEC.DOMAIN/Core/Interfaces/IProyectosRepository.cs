using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IProyectosRepository
    {
        Task<IEnumerable<Proyectos>> GetAllAsync(bool incluirInactivos = false); // Obtener proyectos activos/inactivos.
        Task<Proyectos> GetByIdAsync(int id); // Obtener un proyecto por ID.
        Task<int> AddAsync(Proyectos proyecto); // Insertar un nuevo proyecto.
        Task UpdateAsync(Proyectos proyecto); // Actualizar un proyecto existente.
        Task DeleteLogicallyAsync(int id); // Eliminar lógicamente un proyecto.
        Task DeletePermanentlyAsync(int id); // Eliminar físicamente un proyecto.

        Task<IEnumerable<Proyectos>> ObtenerProyectosPorCliente(int idCliente);
    }
}
