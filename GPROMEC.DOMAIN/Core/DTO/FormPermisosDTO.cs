using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class FormPermisosDTO
    {
        public int IdForm { get; set; }
        public string TituloPermiso { get; set; } = string.Empty;
        public string? DescripPreguntas { get; set; }
    }
}
