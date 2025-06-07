
using Fruteria_vgarcia.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fruteria_vgarcia.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            List<ProductosViewModel> lista = new List<ProductosViewModel>();

            lista = CarritoViewModel.Catalogo();
            return View(lista);
        }
        public ActionResult Carro()
        {
            return View();
        }
        //Añadimos al carro
        public ActionResult AddToCart(int id)
        {
            //using (var db = new FruteriaContext())
            //{
            //    // Retrieve the album from the database
            //    var prod = db.Productos
            //        .Single(p => p.idProducto == id);

            //    // Add it to the shopping cart
            //    var cart = LogicaCarrito.GetCarrito(this.HttpContext);

            //    cart.AddCart(prod);

            // Vueleve al Index
            return RedirectToAction("Index");

        }

    }
}