using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class GimnasioEntidad
    {
        [Key]
        [Required]
        public int CodigoInscripcion { get; set; }
        [Required]
        public int CodigoCliente { get; set; }
        [Required]
        public int CodigoTipoMembresia { get; set; }
        [Required]
        public int CodigoEntrenador { get; set; }
        [Required]
        public int Meses { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public decimal CostoMensual { get; set; }
        [Required]
        public decimal CostoTotal { get; set; }
        [Required]
        public decimal Descuento { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Impuesto { get; set; }
        [Required]
        public decimal TotalPagar { get; set; }



    }
}
