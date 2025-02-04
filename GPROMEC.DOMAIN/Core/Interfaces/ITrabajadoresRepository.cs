using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ITrabajadoresRepository
    {
        Task<IEnumerable<Trabajadores>> GetAllAsync(bool incluirInactivos = false); // Obtener activos/inactivos.
        Task<Trabajadores> GetByIdAsync(int id); // Obtener un trabajador por ID.
        Task<Trabajadores> GetByCorreoAsync(string correo); // Obtener un trabajador por correo.
        Task<int> AddAsync(Trabajadores trabajador); // Insertar un nuevo trabajador.
        Task<bool> UpdateAsync(int id,ActualizarTrabajadorDTO trabajadorDTO); // Actualizar un trabajador.
        Task DeleteLogicallyAsync(int id); // Eliminar lógicamente un trabajador.
        Task DeletePermanentlyAsync(int id); // Eliminar físicamente un trabajador.
    }
}
