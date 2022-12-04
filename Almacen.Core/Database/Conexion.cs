using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.Database {
   public class Conexion {

        public MySqlConnection connection;

        public Conexion() {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection() {
            try {
                connection.Open();
                return true;
            } catch (MySqlException ex) {
                throw ex;
            }
        }

        public bool CloseConnection() {
            try {
                connection.Close();
                return true;
            } catch (MySqlException ex) {
                throw ex;
            }
        }
    }
}
