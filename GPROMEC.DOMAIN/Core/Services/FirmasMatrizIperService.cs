using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class FirmasMatrizIperService : IFirmasMatrizIperService
    {
        private readonly IFirmasMatrizIperRepository _repository;

        public FirmasMatrizIperService(IFirmasMatrizIperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FirmasDTO>> GetAllAsync()
        {
            var firmas = await _repository.GetAllAsync();
            return firmas.Select(f => new FirmasDTO
            {
                IdFirma = f.IdFirma,
                IdPartida = f.IdPartida,
                NombreElaboradoPor = f.ElaboradoPorNavigation?.Nombre,
                NombreRevisadoPor = f.RevisadoPorNavigation?.Nombre,
                NombreAprobadoPor = f.AprobadoPorNavigation?.Nombre,
                FechaElaborado = f.FechaElaborado,
                FechaRevisado = f.FechaRevisado,
                FechaAprobado = f.FechaAprobado,
                FirmaElaboradoUrl = f.FirmaElaboradoUrl,
                FirmaRevisadoUrl = f.FirmaRevisadoUrl,
                FirmaAprobadoUrl = f.FirmaAprobadoUrl
            });
        }

        public async Task<FirmasDTO> GetByIdAsync(int id)
        {
            var firma = await _repository.GetByIdAsync(id);
            if (firma == null) return null;

            return new FirmasDTO
            {
                IdFirma = firma.IdFirma,
                IdPartida = firma.IdPartida,
                NombreElaboradoPor = firma.ElaboradoPorNavigation?.Nombre,
                NombreRevisadoPor = firma.RevisadoPorNavigation?.Nombre,
                NombreAprobadoPor = firma.AprobadoPorNavigation?.Nombre,
                FechaElaborado = firma.FechaElaborado,
                FechaRevisado = firma.FechaRevisado,
                FechaAprobado = firma.FechaAprobado,
                FirmaElaboradoUrl = firma.FirmaElaboradoUrl,
                FirmaRevisadoUrl = firma.FirmaRevisadoUrl,
                FirmaAprobadoUrl = firma.FirmaAprobadoUrl
            };
        }

        public async Task<FirmasDTO> CreateAsync(CrearFirmaDTO firmaDto)
        {
            var firma = new FirmasMatrizIper
            {
                IdPartida = firmaDto.IdPartida,
                ElaboradoPor = firmaDto.ElaboradoPor,
                RevisadoPor = firmaDto.RevisadoPor,
                AprobadoPor = firmaDto.AprobadoPor,
                FirmaElaboradoUrl = Convert.FromBase64String(firmaDto.FirmaElaboradoBase64),
                FirmaRevisadoUrl = Convert.FromBase64String(firmaDto.FirmaRevisadoBase64),
                FirmaAprobadoUrl = Convert.FromBase64String(firmaDto.FirmaAprobadoBase64),
                FechaElaborado = DateTime.UtcNow,
                FechaRevisado = DateTime.UtcNow,
                FechaAprobado = DateTime.UtcNow
            };

            var id = await _repository.CreateAsync(firma);
            return await GetByIdAsync(id);
        }

        public async Task<FirmasDTO> UpdateAsync(int id, ActualizarFirmaDTO firmaDto)
        {
            var firma = await _repository.GetByIdAsync(id);
            if (firma == null) return null;

            firma.ElaboradoPor = firmaDto.ElaboradoPor;
            firma.FirmaElaboradoUrl = Convert.FromBase64String(firmaDto.FirmaElaboradoBase64);
            firma.FechaElaborado = DateTime.UtcNow;

            firma.RevisadoPor = firmaDto.RevisadoPor;
            firma.FirmaRevisadoUrl = Convert.FromBase64String(firmaDto.FirmaRevisadoBase64);
            firma.FechaRevisado = DateTime.UtcNow;

            firma.AprobadoPor = firmaDto.AprobadoPor;
            firma.FirmaAprobadoUrl = Convert.FromBase64String(firmaDto.FirmaAprobadoBase64);
            firma.FechaAprobado = DateTime.UtcNow;

            await _repository.UpdateAsync(firma);
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var firma = await _repository.GetByIdAsync(id);
            if (firma == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<FirmasDTO>> ObtenerFirmasPorMatriz(int id_partida)
        {
            return await _repository.ObtenerFirmasPorMatriz(id_partida);
        }

    }
}
