using Almacen.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Core.Entidades {
    public class Producto2 {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public Proveedor proveedor { get; set; }
        public Categoria categoria { get; set; }
        public int Existencia { get; set; }

        public static Producto2 GetById(int id) {
            Producto2 producto = new Producto2();

            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    string query = "SELECT producto.id, producto.codigo, producto.nombre, producto.precio, proveedor.nombre AS proveedor, categoria.nombre AS categoria, producto.existencia FROM producto INNER JOIN proveedor ON proveedor.nombre = producto.proveedor INNER JOIN categoria ON categoria.nombre = producto.categoria WHERE producto.id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read()) {
                        producto.Id = int.Parse(dataReader["id"].ToString());
                        producto.Codigo = int.Parse(dataReader["codigo"].ToString());
                        producto.Nombre = dataReader["nombre"].ToString();
                        producto.Precio = int.Parse(dataReader["precio"].ToString());
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

        public static List<Producto2> GetAll() {
            List<Producto2> productos = new List<Producto2>();
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    string query = "SELECT producto.id, producto.codigo, producto.nombre, producto.precio, proveedor.nombre AS proveedor, categoria.nombre AS categoria, producto.existencia FROM producto INNER JOIN proveedor ON proveedor.nombre = producto.proveedor INNER JOIN categoria ON categoria.nombre = producto.categoria ORDER BY producto.nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read()) {
                        Producto2 producto = new Producto2();
                        producto.Id = int.Parse(dataReader["id"].ToString());
                        producto.Codigo = int.Parse(dataReader["codigo"].ToString());
                        producto.Nombre = dataReader["nombre"].ToString();
                        producto.Precio = int.Parse(dataReader["precio"].ToString());
                        producto.proveedor.Nombre = dataReader["proveedor"].ToString();
                        producto.categoria.Nombre = dataReader["categoria"].ToString();
                        producto.Existencia = int.Parse(dataReader["existencia"].ToString());

                        productos.Add(producto);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            } catch (Exception ex) {
                throw ex;
            }
            return productos;
        }

        public static bool Guardar(int id, int codigo, string nombre, int precio, string proveedor, string categoria, int existencia) {
            bool result = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0) {
                        cmd.CommandText = " INSERT INTO producto (id, codigo, nombre, precio, proveedor, categoria, existencia) " +
                            "VALUES (@codigo, @nombre, @precio, @proveedor, @categoria, @existencia)";
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@existencia", existencia);

                    } else {
                        cmd.CommandText = " UPDATE producto SET id, codigo, nombre, precio, proveedor, categoria, existencia = @codigo, @nombre, @precio, @proveedor, @categoria, @existencia WHERE id = @id";
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@existencia", existencia);
                    }

                    result = cmd.ExecuteNonQuery() == 1;
                }
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public bool Editar(int id, int codigo, string nombre, int precio, string proveedor, string categoria, int existencia) {
            bool result = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = " UPDATE producto SET id, codigo, nombre, precio, proveedor, categoria, existencia = @codigo, @nombre, @precio, @proveedor, @categoria, @existencia WHERE id = @id ";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@existencia", existencia);

                    result = cmd.ExecuteNonQuery() == 1;
                    
                }
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public static bool Eliminar(int id) {
            bool result = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM producto WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }
        
    }
}
