using LogicaBiblioteca.Contexto;
using LogicaBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaBiblioteca.Managers
{
    public class CarritoManager
    {
        public List<Carrito> ListaCarrito()
        {
            using (var db = new FruteriaContext())
            {
                List<Carrito> carrito = db.Carrito.ToList();
                return carrito;
            }
        }
        public List<Productos> ListaProdutos()
        {
            using (var db = new FruteriaContext())
            {
                List<Productos> carrito = db.Productos.ToList();
                return carrito;
            }
        }

        //public Carrito AddCart(Productos productos)
        //{
        //    using (var db = new FruteriaContext())
        //    {
        //        var carro = db.Carrito.SingleOrDefault(c => productos.idProducto == productos.idProducto && c.idCarrito == idCarrito);
        //        //Crear carro si éste no existe
        //        if (carro == null)
        //        {
        //            carro = new Carrito
        //            {
        //                idProducto = productos.idProducto,

        //                CantidadCompra = 1
        //            };
        //            //Añadir cosas al carrito
        //            db.Carrito.Add(carro);
        //            db.SaveChanges();

        //        }
        //        else
        //        {
        //            //se añade uno o más
        //            carro.CantidadCompra++;
        //        }
        //        //Se guardan los cambios
        //        db.SaveChanges();
        //        return carro;
        //    }
        //}
        public int RemoveProductFromCart(int id)
        {
            using (var db = new FruteriaContext())
            {
                var producto = db.Carrito.SingleOrDefault(
               c => c.idProducto == id);

                int contador = 0;

                if (producto != null)
                {
                    if (producto.CantidadCompra > 1)
                    {
                        producto.CantidadCompra--;
                        contador = producto.CantidadCompra;
                    }
                    else
                    {
                        db.Carrito.Remove(producto);
                    }
                    db.SaveChanges();

                }
                return contador;
            }
        }
        //public void VaciarCarrito()
        //{
        //    using (var db = new FruteriaContext())
        //    {
        //        var carro = db.Carrito.Where(cart => cart.idCarrito == idCarr);

        //        foreach (var cart in carro)
        //        {
        //            db.Carrito.Remove(cart);
        //        }
        //        db.SaveChanges();
        //    }
        //}
        //public List<Carrito> GetCarritos()
        //{
        //    using (var db = new FruteriaContext())
        //    {
        //        return db.Carrito.Where(cart => cart.idCarrito == idCarr).ToList();
        //    }
        //}

    }
}
