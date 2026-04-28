using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class Conexion
    {
        private string CadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexionDB"].ConnectionString;

        public SqlConnection MtdConexionDB()
        {
            return new SqlConnection(CadenaConexion);
        }

    }
}
