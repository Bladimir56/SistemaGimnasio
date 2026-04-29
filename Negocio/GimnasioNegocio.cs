using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
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

        
        #region Codigo Eliminar

        /*  ----- ELIMINAR ----- */

        public bool MtdEliminarInscripcion(int CodigoInscripcion)
        {
            return gimnasioDatos.MtdEliminarInscripcion(CodigoInscripcion);
        }


        #endregion


        #region Codigo BuscarLimpiar

        /* ---- BUSCAR ---- */
        public List<GimnasioEntidad> MtdBuscarInscripcion(int CodigoCliente)
        {
            DataTable dt = gimnasioDatos.MtdBuscarInscripcion(CodigoCliente);

            List<GimnasioEntidad> lista = new List<GimnasioEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                GimnasioEntidad inscripcion = new GimnasioEntidad
                {
                    CodigoInscripcion = Convert.ToInt32(row["CodigoInscripcion"]),
                    CodigoCliente = Convert.ToInt32(row["CodigoCliente"]),
                    CodigoTipoMembresia = Convert.ToInt32(row["CodigoTipoMembresia"]),
                    CodigoEntrenador = Convert.ToInt32(row["CodigoEntrenador"]),
                    Meses = Convert.ToInt32(row["Meses"]),

                    FechaInicio = Convert.ToDateTime(row["FechaInicio"]),


                    CostoMensual = Convert.ToDecimal(row["CostoMensual"]),
                    CostoTotal = Convert.ToDecimal(row["CostoTotal"]),
                    Descuento = Convert.ToDecimal(row["Descuento"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Impuesto = Convert.ToDecimal(row["Impuesto"]),
                    TotalPagar = Convert.ToDecimal(row["TotalPagar"]),

                };

                lista.Add(inscripcion);
            }

            return lista;
        }




        #endregion


    }
}
