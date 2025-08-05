using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Models.Dto
{
    public class SalaCineEstadoDto
    {
        public string? Nombre_Sala { get; set; }
        public int CantidadPeliculas { get; set; }
        public string? Estado_Sala { get; set; } 
    }
}
