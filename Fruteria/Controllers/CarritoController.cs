using System.Web.Mvc;
using Fruteria.ViewModels;
using LogicaBiblioteca.Managers;

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
        public ActionResult AddToCart()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddToCart(int idProducto, int idusuario)
        {
            if (HttpContext.Session["Carro"] != null) { 
            CarritoManager.AddCart(idProducto, idusuario);
            }
            return RedirectToAction("Carro");
        }

        public ActionResult RemoveFromCart(int idProducto)
        {
            CarritoManager.RemoveProductFromCart(idProducto);
            return RedirectToAction("Index");
        }
    }
}
