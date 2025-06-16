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
        public ActionResult AddToCart(ProductosViewModel producto)
        {

           // CarritoManager.AddCart(producto);
            return RedirectToAction("Carro");
        }

        public ActionResult RemoveFromCart(int idProducto)
        {
            CarritoManager.RemoveProductFromCart(idProducto);
            return RedirectToAction("Index");
        }
    }
}
