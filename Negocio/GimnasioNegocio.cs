using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GimnasioNegocio
    {
        GimnasioDatos gimnasioDatos = new GimnasioDatos();

        /*  ----- Consultar -----   */
        public List<GimnasioEntidad> MtdConsultarInscripcion()
        {
            return gimnasioDatos.MtdConsultarInscripcion();
        }


        /*  ----- AGREGAR ----- */

        public bool MtdAgregarInscripcion(GimnasioEntidad inscripcion)
        {
            return gimnasioDatos.MtdAgregarInscripcion(inscripcion);
        }






    }
}
