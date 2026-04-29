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

        /*  ----- CONSULTAR -----   */
        public List<GimnasioEntidad> MtdConsultarInscripcion()
        {
            return gimnasioDatos.MtdConsultarInscripcion();
        }


        /*  ----- AGREGAR ----- */

        public bool MtdAgregarInscripcion(GimnasioEntidad inscripcion)
        {
            return gimnasioDatos.MtdAgregarInscripcion(inscripcion);
        }


        /*  ----- EDITAR ----- */

        public bool MtdEditarInscripcion(GimnasioEntidad inscripcion)
        {

            return gimnasioDatos.MtdEditarInscripcion(inscripcion);
        }





    }
}
