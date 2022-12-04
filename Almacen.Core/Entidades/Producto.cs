using Almacen.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.Entidades {
   public class Producto {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Double Precio { get; set; }
        public Proveedor proveedor { get; set; }
        public Categoria categoria { get; set; }
        public int Existencia { get; set; }

        public static Producto GetById(int id) {
            Producto producto = new Producto();

            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    string query = "SELECT id, codigo, nombre, precio, proveedor, categoria, existencia FROM producto WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) {
                        producto.Id = int.Parse(dataReader["id"].ToString());
                        producto.Codigo = int.Parse(dataReader["codigo"].ToString());
                        producto.Nombre = dataReader["nombre"].ToString();
                        producto.Precio = Double.Parse(dataReader["precio"].ToString());
                        producto.proveedor.Nombre = dataReader["proveedor"].ToString();
                        producto.categoria.Nombre = dataReader["categoria"].ToString();
                        producto.Existencia = int.Parse(dataReader["existencia"].ToString());
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            } catch (Exception ex) {
                throw ex;
            }
            return producto;
        }

        public static List<Producto> GetAll() {
            List<Producto> productos = new List<Producto>();
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    string query = "SELECT id, codigo, nombre, precio, proveedor, categoria, existencia FROM producto ORDER BY nombre";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read()) {
                        Producto producto = new Producto();
                        producto.Id = int.Parse(dataReader["id"].ToString());
                        producto.Codigo = int.Parse(dataReader["codigo"].ToString());
                        producto.Nombre = dataReader["nombre"].ToString();
                        producto.Precio = Double.Parse(dataReader["precio"].ToString());
                        producto.proveedor.Nombre = dataReader["proveedor"].ToString();
                        producto.categoria.Nombre = dataReader["categoria"].ToString();
                        producto.Existencia = int.Parse(dataReader["existencia"].ToString());

                        productos.Add(producto);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            } catch (Exception e) {
                throw e;
            }
            return productos;
        }

    }
}
