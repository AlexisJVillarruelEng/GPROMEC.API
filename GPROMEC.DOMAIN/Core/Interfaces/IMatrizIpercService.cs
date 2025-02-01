using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IMatrizIpercService
    {
        Task<MatrizIpercDTO> ObtenerMatrizPorPartida(int idPartida);
        Task<bool> ActualizarMatriz(MatrizIpercDTO matriz);
        Task<int> CrearMatriz(MatrizIpercDTO matriz);
        Task<bool> EliminarMatriz(int idPartida);
    }

}
