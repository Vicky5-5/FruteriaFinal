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

        public ActionResult AddToCart(int idProducto)
        {
            ProductosViewModel producto = new ProductosViewModel { idProducto = idProducto };
            CarritoViewModel carrito = new CarritoViewModel(CarritoManager.AddCart(producto));
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int idProducto)
        {
            CarritoManager.RemoveProductFromCart(idProducto);
            return RedirectToAction("Index");
        }
    }
}
