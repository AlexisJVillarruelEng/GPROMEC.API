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
    public class UbigeoService : IUbigeoService
    {
        private readonly IUbigeoRepository _repository;

        public UbigeoService(IUbigeoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UbigeoDTO>> GetAllAsync()
        {
            var ubigeos = await _repository.GetAllAsync();
            return ubigeos.Select(u => new UbigeoDTO
            {
                IdUbigeo = u.IdUbigeo,
                Departamento = u.Departamento,
                Provincia = u.Provincia,
                Distrito = u.Distrito
            });
        }

        public async Task<UbigeoDTO> GetByIdAsync(int id)
        {
            var ubigeo = await _repository.GetByIdAsync(id);
            if (ubigeo == null) return null;

            return new UbigeoDTO
            {
                IdUbigeo = ubigeo.IdUbigeo,
                Departamento = ubigeo.Departamento,
                Provincia = ubigeo.Provincia,
                Distrito = ubigeo.Distrito
            };
        }

        public async Task<int> AddAsync(CrearUbigeoDTO ubigeoDto)
        {
            var ubigeo = new Ubigeo
            {
                Departamento = ubigeoDto.Departamento,
                Provincia = ubigeoDto.Provincia,
                Distrito = ubigeoDto.Distrito
            };

            return await _repository.AddAsync(ubigeo);
        }

        public async Task UpdateAsync(int id, CrearUbigeoDTO ubigeoDto)
        {
            var ubigeo = new Ubigeo
            {
                IdUbigeo = id,
                Departamento = ubigeoDto.Departamento,
                Provincia = ubigeoDto.Provincia,
                Distrito = ubigeoDto.Distrito
            };

            await _repository.UpdateAsync(ubigeo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
