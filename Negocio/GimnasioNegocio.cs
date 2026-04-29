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


        #region Codigo Consultar 
        /*  ----- CONSULTAR -----   */
        public List<GimnasioEntidad> MtdConsultarInscripcion()
        {
            return gimnasioDatos.MtdConsultarInscripcion();
        }
        #endregion


        #region Codigo Agregar
        /*  ----- AGREGAR ----- */

        public bool MtdAgregarInscripcion(GimnasioEntidad inscripcion)
        {
            return gimnasioDatos.MtdAgregarInscripcion(inscripcion);
        }
        #endregion


        #region Codigo Editar
        /*  ----- EDITAR ----- */

        public bool MtdEditarInscripcion(GimnasioEntidad inscripcion)
        {

            return gimnasioDatos.MtdEditarInscripcion(inscripcion);
        }

        #endregion



    }
}
