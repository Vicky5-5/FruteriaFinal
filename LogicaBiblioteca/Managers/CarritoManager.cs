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

        public static Carrito AddCart(int idProducto, int idUsuario, int cantidad)
        {
            if (idProducto <= 0 || idUsuario <= 0 || cantidad <= 0)
                throw new ArgumentException("Parámetros inválidos.");

            using (var db = new FruteriaContext())
            {
                //var producto = db.Productos.FirstOrDefault(p => p.idProducto == idProducto);
                var producto = ProductosManager.ObtenerProducto(idProducto);
                if (producto == null)
                    throw new Exception("Producto no encontrado.");

                if (producto.Stock < cantidad)
                    throw new Exception("Stock insuficiente.");

                // Descontar del stock real
                producto.Stock -= cantidad;

                var carro = db.Carrito.FirstOrDefault(c => c.idProducto == idProducto && c.idUsuario == idUsuario);
                if (carro == null)
                {
                    carro = new Carrito
                    {
                        idProducto = idProducto,
                        idUsuario = idUsuario,
                        CantidadCompra = cantidad
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
