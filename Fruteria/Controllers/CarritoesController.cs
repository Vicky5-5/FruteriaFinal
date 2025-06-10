using LogicaBiblioteca.Logica;
using System.Web.Mvc;

namespace Fruteria.Controllers
{
    public class CarritoesController : Controller
    {
        // GET: Carritoes
        //public ActionResult Index()
        //{
        //    var carro = LogicaCarrito.GetCarrito(this.HttpContext);

        //    var viewModel = new CarritoViewModel
        //    {
        //        oCarrito = carro.GetCarritos(),
        //        totalCar = carro.ObtenerTotalProductos()
        //    };
        //    return View(viewModel);
        //}
        //public ActionResult ListaCompras()
        //{
        //    return View(db.Productos.ToList());
        //}

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
        //[HttpPost]
        //public ActionResult BorrarProducto(int id)
        //{
        //    using (var db = new FruteriaContext())
        //    {
        //        var carro = LogicaCarrito.GetCarrito(this.HttpContext);

        //        string nombreProducto = db.Carrito.Single(c => c.idProducto == id).NombreProducto;

        //        int contador = carro.EliminarDelCarro(id);

        //        var resultado = new CarritoEliminarViewModel
        //        {
        //            mensaje = Server.HtmlEncode(nombreProducto) + " se ha eliminado del carrito", //Se crea un mensaje que informa que tal prducto se eliminó del carrito
        //            totalCar = carro.ObtenerTotalProductos(), //Obtenemos el total del carrito
        //            contadorCarrito = carro.GetCount(),  //Se cuenta la cantidad de productos que hay en el carrito
        //            contadorProducto = contador, //Se cuenta la cantidad de un mismo producto
        //            idBorrado = id
        //        };
        //        return Json(resultado);
        //    }
        //}
        [ChildActionOnly]
        public ActionResult Resumen()
        {
            var carrito = LogicaCarrito.GetCarrito(this.HttpContext);

            ViewData["contadorCarrito"] = carrito.GetCount();
            return PartialView("Resumen");
        }
    }
}
