using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    // Clase para manejar el contexto de la base de datos
    public class ContextoDB
    {
        // Propiedad para obtener la cadena de conexión
        private static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión de la configuración
                string cadenaConexion = ConfigurationManager
                    .ConnectionStrings["CRUD"]
                    .ConnectionString;

                // Crea un constructor de cadena de conexión SQL
                SqlConnectionStringBuilder connectionBuilder =
                    new SqlConnectionStringBuilder(cadenaConexion);

                // Asigna el nombre de la aplicación si se ha configurado
                connectionBuilder.ApplicationName =
                    ApplicationName ?? connectionBuilder.ApplicationName;

                // Establece el tiempo de espera de conexión si es mayor a 0
                connectionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : connectionBuilder.ConnectTimeout;

                // Retorna la cadena de conexión construida
                return connectionBuilder.ToString();
            }
        }

        // Propiedad estática para establecer el nombre de la aplicación
        public static string ApplicationName { get; set; }

        // Propiedad estática para establecer el tiempo de espera de la conexión
        public static int ConnectionTimeout { get; set; }

        // Método para obtener una conexión SQL abierta
        public static SqlConnection ObtenerCadena()
        {
            var cadena = new SqlConnection(ConnectionString); // Crea una nueva conexión SQL
            cadena.Open(); // Abre la conexión
            return cadena; // Retorna la conexión abierta
        }
    }
}