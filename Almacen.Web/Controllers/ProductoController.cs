using Almacen.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen.Web.Controllers{
    public class ProductoController : Controller{

         
        public ActionResult Index() {
            List<Producto> productos = Producto.GetAll();
            return View(productos);
        }

        public ActionResult Registro(int id) {
            Producto producto = Producto.GetById(id);
            return View(producto);
        }

        public ActionResult Guardar(int id, int codigo, string nombre, int precio, string proveedor, string categoria, int existencia) {
            Producto2.Guardar(id, codigo, nombre, precio, categoria, proveedor, existencia);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id) {
            Producto2.Eliminar(id);
            return RedirectToAction("Index");
        }

      
    }
}