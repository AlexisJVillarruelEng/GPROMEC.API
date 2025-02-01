using GPROMEC.DOMAIN.Infrastructure.Data;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class MatrizIpercService : IMatrizIpercService
    {
        private readonly IMatrizIpercRepository _matrizIpercRepository;

        public MatrizIpercService(IMatrizIpercRepository matrizIpercRepository)
        {
            _matrizIpercRepository = matrizIpercRepository;
        }

        public async Task<MatrizIpercDTO> ObtenerMatrizPorPartida(int idPartida)
        {
            return await _matrizIpercRepository.ObtenerMatrizPorPartida(idPartida);
        }

        public async Task<bool> ActualizarMatriz(MatrizIpercDTO matriz)
        {
            return await _matrizIpercRepository.ActualizarMatriz(matriz);
        }

        public async Task<int> CrearMatriz(MatrizIpercDTO matriz)
        {
            return await _matrizIpercRepository.CrearMatriz(matriz);
        }

        public async Task<bool> EliminarMatriz(int idPartida)
        {
            return await _matrizIpercRepository.EliminarMatriz(idPartida);
        }
    }
}
