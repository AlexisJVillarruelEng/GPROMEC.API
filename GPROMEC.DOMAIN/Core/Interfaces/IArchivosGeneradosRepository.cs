using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IArchivosGeneradosRepository
    {
        Task<int> CrearArchivoAsync(ArchivoGeneradoCrearDto archivoDto);
        Task<int> ActualizarArchivoAsync(int id, ArchivoGeneradoCrearDto archivoDto, string generadoPor);
        Task<bool> EliminarLogicamenteAsync(int id);
        Task<ArchivoGeneradoDto> ObtenerArchivoPorIdAsync(int id);
        Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorProyectoAsync(int idRelacion);
        Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorCarpetaAsync(string carpeta);
        Task<byte[]> ObtenerArchivoBinarioAsync(int id);
        Task<IEnumerable<ArchivoGeneradoDto>> GetAllAsync();
    }
}