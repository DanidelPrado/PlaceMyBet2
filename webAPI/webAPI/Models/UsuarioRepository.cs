using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class UsuarioRepository
    {
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Usuario> retrieve()
        {
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM usuario";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Usuario> usuario = new List<Usuario>();

                while (reader.Read())
                {
                    Usuario e = new Usuario(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    usuario.Add(e);

                }
                conectar.Close();
                return usuario;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
        }
    }
}