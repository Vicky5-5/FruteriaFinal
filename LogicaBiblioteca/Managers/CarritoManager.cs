using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fruteria.ViewModels;
using LogicaBiblioteca.Contexto;
using LogicaBiblioteca.Modelos;
using static System.Collections.Specialized.BitVector32;

namespace LogicaBiblioteca.Managers
{
    public class CarritoManager
    {
        public static List<Carrito> ListaCarrito()
        {
            using (var db = new FruteriaContext())
            {
                return db.Carrito.ToList();
            }
        }

        public static Carrito AddCart(int idProducto, int idUsuario)
        {
            if (idProducto == 0)
            {
                HttpContext.Current.Session["NoProductos"] = "No hay productos";
            }
            if (idUsuario == 0)
            {
                HttpContext.Current.Session["NoUsuario"] = "No hay usuario";
            }
            using (var db = new FruteriaContext())
            {
                //var carrito = Session.GetObject<Carrito>("Carrito") ?? new Carrito();

                var carro = db.Carrito.FirstOrDefault(c => c.idProducto == idProducto && c.idUsuario == idUsuario)
            ?? new Carrito { idProducto = idProducto, idUsuario = idUsuario, CantidadCompra = 0 };

                carro.CantidadCompra++;
                if (carro.idCarrito == 0) db.Carrito.Add(carro); // Solo agregar si es nuevo

                db.SaveChanges();
                return carro;

            }
        }


        public static void RemoveProductFromCart(int id)
        {
            using (var db = new FruteriaContext())
            {
                var producto = db.Carrito.SingleOrDefault(c => c.idProducto == id);
                if (producto != null)
                {
                    db.Carrito.Remove(producto);
                    db.SaveChanges();
                }
            }
        }
    }
}
