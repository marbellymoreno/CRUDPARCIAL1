using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PostresDAL
    {
        // Lista para almacenar los postres
        List<Postres> Postres = new List<Postres>();

        // Método para obtener todos los postres de la base de datos
        public List<Postres> ObtenerPostres()
        {
            // Obtener la cadena de conexión de la base de datos
            using (var cadena = ContextoDB.ObtenerCadena())
            {
                // Consulta SQL para seleccionar todos los postres
                String commandSql = "";
                commandSql = commandSql + "SELECT [IdPostre] " + "\n";
                commandSql = commandSql + "      ,[Nombre] " + "\n";
                commandSql = commandSql + "      ,[Descripcion] " + "\n";
                commandSql = commandSql + "      ,[Precio] " + "\n";
                commandSql = commandSql + "      ,[FechaVencimiento] " + "\n";
                commandSql = commandSql + "      ,[Estado] " + "\n";
                commandSql = commandSql + "      ,[Stock] " + "\n";
                commandSql = commandSql + "      ,[Calorias] " + "\n";
                commandSql = commandSql + "  FROM [dbo].[Postres]";

                // Crear el comando SQL y ejecutar la consulta
                using (SqlCommand comando = new SqlCommand(commandSql, cadena))
                {
                    SqlDataReader reader = comando.ExecuteReader();

                    // Leer cada fila del DataReader y agregarla a la lista de postres
                    while (reader.Read())
                    {
                        var postres = LeerDelDataReader(reader);
                        Postres.Add(postres);
                    }
                    // Devolver la lista de postres
                    return Postres;
                }
            }
        }

        // Método para leer un postre desde el DataReader
        public Postres LeerDelDataReader(SqlDataReader reader)
        {
            // Crear un objeto Postres y asignar valores desde el DataReader
            Postres postres = new Postres
            {
                IdPostre = reader["IdPostre"] == DBNull.Value ? 0 : (int)reader["IdPostre"], // Leer el IdPostre, manejar valores nulos
                Nombre = reader["Nombre"] == DBNull.Value ? null : (string)reader["Nombre"], // Leer el Nombre, manejar valores nulos
                Descripcion = reader["Descripcion"] == DBNull.Value ? null : (string)reader["Descripcion"], // Leer la Descripcion, manejar valores nulos
                Precio = reader["Precio"] == DBNull.Value ? 0 : (decimal)reader["Precio"], // Leer el Precio, manejar valores nulos
                FechaVencimiento = reader["FechaVencimiento"] == DBNull.Value ? default(DateTime) : (DateTime)reader["FechaVencimiento"], // Leer FechaVencimiento, manejar valores nulos
                Estado = reader["Estado"] == DBNull.Value ? false : (bool)reader["Estado"], // Leer el Estado, manejar valores nulos
                Stock = reader["Stock"] == DBNull.Value ? 0 : (int)reader["Stock"], // Leer el Stock, manejar valores nulos
                Calorias = reader["Calorias"] == DBNull.Value ? 0 : (int)reader["Calorias"] // Leer las Calorias, manejar valores nulos
            };

            return postres;
        }

        // Método para obtener un postre específico por su ID
        public Postres ObtenerPostresPorId(int id)
        {
            // Obtener la cadena de conexión de la base de datos
            using (var cadena = ContextoDB.ObtenerCadena())
            {
                // Consulta SQL para seleccionar un postre específico por ID
                String commandSql = "";
                commandSql = commandSql + "SELECT [IdPostre] " + "\n";
                commandSql = commandSql + "      ,[Nombre] " + "\n";
                commandSql = commandSql + "      ,[Descripcion] " + "\n";
                commandSql = commandSql + "      ,[Precio] " + "\n";
                commandSql = commandSql + "      ,[FechaVencimiento] " + "\n";
                commandSql = commandSql + "      ,[Estado] " + "\n";
                commandSql = commandSql + "      ,[Stock] " + "\n";
                commandSql = commandSql + "      ,[Calorias] " + "\n";
                commandSql = commandSql + "  FROM [dbo].[Postres]" + "\n";
                commandSql = commandSql + "  WHERE [IdPostre] = @IdPostre";

                // Crear el comando SQL, agregar parámetros y ejecutar la consulta
                using (SqlCommand comando = new SqlCommand(commandSql, cadena))
                {
                    comando.Parameters.AddWithValue("@IdPostre", id); // Agregar el parámetro IdPostre
                    SqlDataReader reader = comando.ExecuteReader();
                    Postres Postres2 = null;

                    // Leer el resultado y asignar el postre encontrado
                    while (reader.Read())
                    {
                        Postres2 = LeerDelDataReader(reader);
                    }
                    // Devolver el postre encontrado
                    return Postres2;
                }
            }
        }

        // Método para obtener postres por nombre
        public List<Postres> ObtenerPostresPorNombre(string nombre)
        {
            // Obtener la cadena de conexión de la base de datos
            using (var cadena = ContextoDB.ObtenerCadena())
            {
                // Consulta SQL para seleccionar postres por nombre
                String commandSql = "";
                commandSql = commandSql + "SELECT [IdPostre] " + "\n";
                commandSql = commandSql + "      ,[Nombre] " + "\n";
                commandSql = commandSql + "      ,[Descripcion] " + "\n";
                commandSql = commandSql + "      ,[Precio] " + "\n";
                commandSql = commandSql + "      ,[FechaVencimiento] " + "\n";
                commandSql = commandSql + "      ,[Estado] " + "\n";
                commandSql = commandSql + "      ,[Stock] " + "\n";
                commandSql = commandSql + "      ,[Calorias] " + "\n";
                commandSql = commandSql + "  FROM [dbo].[Postres]" + "\n";
                commandSql = commandSql + "  WHERE [Nombre] = @Nombre";

                // Crear el comando SQL, agregar parámetros y ejecutar la consulta
                using (SqlCommand comando = new SqlCommand(commandSql, cadena))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre); // Agregar el parámetro Nombre
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Postres> Postres2 = new List<Postres>();

                    // Leer cada fila del DataReader y agregarla a la lista de postres
                    while (reader.Read())
                    {
                        var postres = LeerDelDataReader(reader);
                        Postres2.Add(postres);
                    }
                    // Devolver la lista de postres encontrados
                    return Postres2;
                }
            }
        }

        // Método para filtrar postres por nombre
        public List<Postres> Filtrar(string Nombre)
        {
            ObtenerPostres(); // Obtener todos los postres
            var filltro = Postres.FindAll(x => x.Nombre.ToUpper().StartsWith(Nombre.ToUpper())); // Filtrar postres por nombre
            return filltro; // Devolver la lista filtrada
        }

        // Método para insertar un nuevo postre en la base de datos
        public int InsertarPostre(Postres postre)
        {
            // Consulta SQL para insertar un nuevo postre
            string query = @"
            INSERT INTO [dbo].[Postres] 
                ([Nombre], [Descripcion], [Precio], [FechaVencimiento], [Estado], [Stock], [Calorias])
            VALUES 
                (@Nombre, @Descripcion, @Precio, @FechaVencimiento, @Estado, @Stock, @Calorias)";

            // Obtener la cadena de conexión de la base de datos
            using (var conexion = ContextoDB.ObtenerCadena())
            {
                // Crear el comando SQL, agregar parámetros y ejecutar la inserción
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    // Agregar parámetros al comando
                    command.Parameters.AddWithValue("@Nombre", postre.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", postre.Descripcion);
                    command.Parameters.AddWithValue("@Precio", postre.Precio);
                    command.Parameters.AddWithValue("@FechaVencimiento", postre.FechaVencimiento);
                    command.Parameters.AddWithValue("@Estado", postre.Estado);
                    command.Parameters.AddWithValue("@Stock", postre.Stock);
                    command.Parameters.AddWithValue("@Calorias", postre.Calorias);

                    // Confirmar la inserción y devolver el número de filas afectadas
                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas;
                }
            }
        }

        // Método para actualizar un postre en la base de datos
        public int ActualizarPostre(Postres postre)
        {
            // Consulta SQL para actualizar un postre existente
            string query = @"
                UPDATE [dbo].[Postres]
                SET 
                    [Nombre] = @Nombre,
                    [Descripcion] = @Descripcion,
                    [Precio] = @Precio,
                    [FechaVencimiento] = @FechaVencimiento,
                    [Estado] = @Estado,
                    [Stock] = @Stock,
                    [Calorias] = @Calorias
                WHERE [IdPostre] = @IdPostre";

            // Obtener la cadena de conexión de la base de datos
            using (var conexion = ContextoDB.ObtenerCadena())
            {
                // Crear el comando SQL, agregar parámetros y ejecutar la actualización
                using (var comando = new SqlCommand(query, conexion))
                {
                    // Agregar parámetros al comando
                    comando.Parameters.AddWithValue("@IdPostre", postre.IdPostre);
                    comando.Parameters.AddWithValue("@Nombre", postre.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", postre.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", postre.Precio);
                    comando.Parameters.AddWithValue("@FechaVencimiento", postre.FechaVencimiento);
                    comando.Parameters.AddWithValue("@Estado", postre.Estado);
                    comando.Parameters.AddWithValue("@Stock", postre.Stock);
                    comando.Parameters.AddWithValue("@Calorias", postre.Calorias);

                    // Ejecutar la actualización y devolver el número de filas afectadas
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas;
                }
            }
        }

        // Método para eliminar un postre de la base de datos por su ID
        public int EliminarPostre(int idPostre)
        {
            // Consulta SQL para eliminar un postre por ID
            string query = "DELETE FROM [dbo].[Postres] WHERE [IdPostre] = @IdPostre";

            // Obtener la cadena de conexión de la base de datos
            using (var conexion = ContextoDB.ObtenerCadena())
            {
                // Crear el comando SQL, agregar parámetros y ejecutar la eliminación
                using (var comando = new SqlCommand(query, conexion))
                {
                    // Agregar parámetro al comando
                    comando.Parameters.AddWithValue("@IdPostre", idPostre);

                    // Ejecutar la eliminación y devolver el número de filas afectadas
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas;
                }
            }
        }
    }
}
