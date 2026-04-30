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


        #region Metodos Sistema

        /*-------METODOS-------*/

        const double PorcentajeDescuento = 0.10;
        const double PorcentajeImpuesto = 0.12;

        // Método CostoMensual
        public double MtdCostoMensual(int TipoMembresia)
        {
            //Enviando segun el tipo de mebresia se asigna un costo mensual
            if (TipoMembresia == 1) return 450;
            else if (TipoMembresia == 2) return 500;
            else if (TipoMembresia == 3) return 515;
            else if (TipoMembresia == 4) return 716;
            else if (TipoMembresia == 5) return 950;
            return 0;
        }
        

        //Metodo Costo total
        public double MtdCostoTotal(int Meses, double CostoMensual)
        {
            return Meses * CostoMensual;
        }

        //Metodo Descuento
        public double MtdDescuento(int Meses, double CostoTotal)
        {
            if (Meses >= 6)
                return CostoTotal * PorcentajeDescuento; 

            return 0;
        }

        //Metodo Subtotal
        public double MtdSubTotal(double CostoTotal, double Descuento)
        {
            return CostoTotal - Descuento;
        }

        //Metodo Impuesto
        public double MtdImpuesto(double SubTotal)
        {
            return SubTotal * PorcentajeImpuesto;
        }


        //Metodo TotalPagar
        public double MtdTotalPagar(double SubTotal, double Impuesto)
        {
            return SubTotal + Impuesto;
        }

        #endregion


    }
}
