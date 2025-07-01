using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Fruteria.ViewModels;
using LogicaBiblioteca.Managers;
using LogicaBiblioteca.Modelos;

namespace Fruteria.Controllers
{
    public class CarritoController : Controller
    {
        public ActionResult Index()
        {
            var carrito = ProductosViewModel.ListProductos();
            return View(carrito);
        }
        [HttpGet]
        public ActionResult ListaCompras()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ListaCompras(int idProducto, int idUsuario, int cantidad)
        {
            var nuevoItem = CarritoManager.AddCart(idProducto, idUsuario, cantidad);

            if (HttpContext.Session["Carro"] == null)
            {
                var carritoSesion = HttpContext.Session["Carro"] as List<Carrito> ?? new List<Carrito>();
                carritoSesion.Add(nuevoItem);
                HttpContext.Session["Carro"] = carritoSesion;
            }
            var productos = ProductosManager.ListarProductos(); // retorna List<Productos>

            return View(productos);
        }


        public ActionResult RemoveFromCart(int idProducto)
        {
            CarritoManager.RemoveProductFromCart(idProducto);
            return RedirectToAction("Index");
        }
    }
}
