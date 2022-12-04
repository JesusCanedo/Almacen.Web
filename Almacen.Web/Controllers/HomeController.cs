using Almacen.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen.Web.Controllers{
    public class HomeController : Controller {

        // Acciones de controlador
        public ActionResult Index() {
            Producto.GetAll();
            return View();
        }

        public ActionResult Bienvenida() {
            return View();
        }

    }
}