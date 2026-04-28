using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class GimnasioDatos
    {
        Conexion conexionDatos = new Conexion(); // Instanciar

        /*  ----- CONSULTAR -----   */
        public List<GimnasioEntidad> MtdConsultarInscripcion()
        {
            List<GimnasioEntidad> listaInscripcion = new List<GimnasioEntidad>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexionDB())
                {
                    conn.Open();
                    string QueryListarInscripcion = "Select * From Tbl_Inscripcion order by CodigoInscripcion asc;";

                    using (SqlCommand cmd = new SqlCommand(QueryListarInscripcion, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listaInscripcion.Add(new GimnasioEntidad()
                                {

                                    CodigoInscripcion = Convert.ToInt32(dr["CodigoInscripcion"]),
                                    CodigoCliente = Convert.ToInt32(dr["CodigoCliente"]),
                                    CodigoTipoMembresia = Convert.ToInt32(dr["CodigoTipoMembresia"]),
                                    CodigoEntrenador = Convert.ToInt32(dr["CodigoEntrenador"]),
                                    Meses = Convert.ToInt32(dr["Meses"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),

                                    CostoMensual = Convert.ToDecimal(dr["CostoMensual"]),
                                    CostoTotal = Convert.ToDecimal(dr["CostoTotal"]),
                                    Descuento = Convert.ToDecimal(dr["Descuento"]),
                                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                    Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                                    TotalPagar = Convert.ToDecimal(dr["TotalPagar"]),


                                });
                            }
                        }
                    }

                }
                return listaInscripcion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista" + ex.Message);
            }
        }

        /*  ----- AGREGAR ----- */
        public bool MtdAgregarInscripcion(GimnasioEntidad inscripcion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexionDB())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Inscripcion
	                                        (
		                                        CodigoCliente,
		                                        CodigoTipoMembresia,
		                                        CodigoEntrenador,
		                                        Meses,
		                                        FechaInicio,
		                                        CostoMensual,
		                                        CostoTotal,
		                                        Descuento,
		                                        SubTotal,
		                                        Impuesto,
		                                        TotalPagar
	                                        )
	                                        VALUES
	                                        (
		                                        @CodigoCliente,
		                                        @CodigoTipoMembresia,
		                                        @CodigoEntrenador,
		                                        @Meses,
		                                        @FechaInicio,
		                                        @CostoMensual,
		                                        @CostoTotal,
		                                        @Descuento,
		                                        @SubTotal,
		                                        @Impuesto,
		                                        @TotalPagar
	                                        );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {


                        cmd.Parameters.AddWithValue("@@CodigoCliente", inscripcion.CodigoCliente);
                        cmd.Parameters.AddWithValue("@CodigoTipoMembresia", inscripcion.CodigoTipoMembresia);
                        cmd.Parameters.AddWithValue("@CodigoEntrenador", inscripcion.CodigoEntrenador);
                        cmd.Parameters.AddWithValue("@Meses", inscripcion.Meses);
                        cmd.Parameters.AddWithValue("@FechaInicio", inscripcion.FechaInicio);
                        cmd.Parameters.AddWithValue("@CostoMensual", inscripcion.CostoMensual);
                        cmd.Parameters.AddWithValue("@CostoTotal", inscripcion.CostoTotal);
                        cmd.Parameters.AddWithValue("@Descuento", inscripcion.Descuento);
                        cmd.Parameters.AddWithValue("@SubTotal", inscripcion.SubTotal);
                        cmd.Parameters.AddWithValue("@Impuesto", inscripcion.Impuesto);
                        cmd.Parameters.AddWithValue("@TotalPagar", inscripcion.TotalPagar);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar inscripción en la base de datos", ex);
            }
        }

            
    }
}
