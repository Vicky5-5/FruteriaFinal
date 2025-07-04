using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public static Carrito AddCart(int idProducto, string nombreP, int idUsuario, int cantidad)
        {
            if (idProducto <= 0 || idUsuario <= 0 || cantidad <= 0)
                throw new ArgumentException("ID de producto, usuario o cantidad no válidos.");

            using (var db = new FruteriaContext())
            {
                var carro = db.Carrito
                    .FirstOrDefault(c => c.idProducto == idProducto && c.idUsuario == idUsuario);

                if (carro == null)
                {
                    carro = new Carrito
                    {
                        idProducto = idProducto,
                        idUsuario = idUsuario,
                        CantidadCompra = cantidad,
                        //oProducto.NombreProducto = nombreP
                    };
                    db.Carrito.Add(carro);
                }
                else
                {
                    carro.CantidadCompra += cantidad;
                }

                db.SaveChanges();
                return carro;
            }
        }

        public static List<Carrito> ObtenerCarritoPorUsuario(int idUsuario)
        {
            using (var db = new FruteriaContext())
            {
                return db.Carrito
                         .Where(c => c.idUsuario == idUsuario)
                         .ToList();
            }
        }
        public static Pedidos ProcesarCompra(int id, int idUsuario, bool estadoPedido, decimal total, string nombreProductos)
        {

            using (var db = new FruteriaContext())
            {

                var pedido = db.Pedidos.FirstOrDefault(a => a.idPedido == id);


                //Esto es para crear un nuevo producto
                pedido = new Pedidos()
                {

                    idPedido = id,
                    idUsuario = idUsuario,
                    FechaPedido = DateTime.Now,
                    FechaEstimadaEntrega = DateTime.Now.AddDays(4), //Para dentro de cuatro días
                    EstadoPedido = estadoPedido,
                    Total = total,

                };

                try
                {
                    db.Pedidos.Add(pedido);

                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw new Exception(ex.Message);
                }

                return pedido;
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
