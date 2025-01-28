using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IArchivosGeneradosService
    {
        Task<int> CrearArchivoAsync(ArchivoGeneradoCrearDto archivoDto);
        Task<int> ActualizarArchivoAsync(int id, ArchivoGeneradoCrearDto archivoDto, string generadoPor);
        Task<bool> EliminarLogicamenteAsync(int id);
        Task<ArchivoGeneradoDto> ObtenerArchivoPorIdAsync(int id);
        Task<byte[]> DescargarArchivoAsync(int id);
        Task<byte[]> DescargarArchivosComoZipAsync(int idRelacion);
        Task<byte[]> DescargarArchivosPorCarpetaAsync(string carpeta);
        Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorProyectoAsync(int proyectoId);
        Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorCarpetaAsync(string carpeta);
    }
}