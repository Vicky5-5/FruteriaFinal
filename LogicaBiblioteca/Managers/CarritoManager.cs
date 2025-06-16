using System.Collections.Generic;
using System.Linq;
using Fruteria.ViewModels;
using LogicaBiblioteca.Contexto;
using LogicaBiblioteca.Modelos;

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

        public static Carrito AddCart(ProductosViewModel productos, UsuariosViewModel usuario)
        {
            using (var db = new FruteriaContext())
            {
                var carro = db.Carrito.SingleOrDefault(c => c.idProducto == productos.idProducto && c.idUsuario == usuario.idUsuario);

                if (carro == null)
                {
                    carro = new Carrito
                    {
                        idProducto = productos.idProducto,
                        CantidadCompra = 1
                    };
                    db.Carrito.Add(carro);
                }
                else
                {
                    carro.CantidadCompra++;
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
