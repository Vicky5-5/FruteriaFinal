using Fruteria_vgarcia.ViewModels;
using LogicaBiblioteca.Contexto;
using LogicaBiblioteca.Modelos;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Fruteria_vgarcia.Controllers
{
    public class DetallesPedidosController : Controller
    {
        private FruteriaContext db = new FruteriaContext();

        //Esto lo ve el admin
        public ActionResult Index()
        {
            List<DetallesPedidosViewModel> lista = new List<DetallesPedidosViewModel>();

            DetallesPedidosViewModel viewModel = new DetallesPedidosViewModel();
            lista = viewModel.ListTodosProductos();
            return View(lista);
        }

        // GET: DetallesPedidos/Details/5
        public ActionResult Details(int? id)
        {
            using (var db = new FruteriaContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DetallesPedidos detallesPedidos = db.DetallesPedidos.Find(id);
                if (detallesPedidos == null)
                {
                    return Json(new { sucess = false, message = "No hay pedidos" });
                }
                return View(detallesPedidos);
            }
        }

        //public ActionResult VerDetallesProductosUnUsuario(string email, string password)
        //{

        //}

      
    }
}
