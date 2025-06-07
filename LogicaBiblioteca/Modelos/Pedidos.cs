using LogicaBiblioteca.Contexto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Contexts;

namespace LogicaBiblioteca.Modelos
{
    public class Pedidos
    {
        [Key]
        public int idPedido { get; set; }
        public int idUsuario { get; set; }
        public DateTime FechaPedido { get; set; }

        public DateTime FechaEstimadaEntrega { get; set; }
        public bool EstadoPedido { get; set; }
        public decimal Total { get; set; }
        public Productos oProductos { get; set; }
        public List<DetallesPedidos> DetallesPedidos { get; set; }

        //public int CrearPedido(DetallesPedidos detalle)
        //{
        //    using (var db = new FruteriaContext())
        //    {
        //        Carrito carrito = new Carrito();
        //        decimal totalPedido = 0; // Para acumular el total del pedido
        //        var items = carrito.GetCarritos(); // Obtener los productos del carrito

        //        // Crear instancia del pedido
        //        Pedidos nuevoPedido = new Pedidos
        //        {
        //            idUsuario = detalle.Pedidos.idUsuario, // Obtenemos el ID del Usuario
        //            FechaPedido = DateTime.Now,
        //            FechaEstimadaEntrega = DateTime.Now.AddDays(5), // Entrega en 5 días
        //            EstadoPedido = true,
        //            Total = 0, // Se calculará más adelante
        //            DetallesPedidos = new List<DetallesPedidos>() // Inicializar lista vacía
        //        };

        //        foreach (var item in items)
        //        {
        //            // Crear los detalles del pedido
        //            DetallesPedidos detalleP = new DetallesPedidos
        //            {
        //                //Implementar la oferta
        //                idProducto = item.idProducto,
        //                Cantidad = item.CantidadCompra,
        //                Precio = item.totalProductos, // Asumiendo que el precio está en `Productos`
        //                PrecioTotal = item.CantidadCompra * item.totalProductos,
        //                // Productos = item // Relación con la clase `Productos`
        //            };

        //            // Sumar al total del pedido
        //            totalPedido += detalleP.PrecioTotal;

        //            // Añadir el detalle al pedido
        //            nuevoPedido.DetallesPedidos.Add(detalleP);
        //        }

        //        // Actualizar el total en el pedido
        //        nuevoPedido.Total = totalPedido;

        //        // Guardar el pedido en la base de datos (asumiendo que el contexto tiene un DbSet<Pedidos>)
        //        db.Pedidos.Add(nuevoPedido);
        //        db.SaveChanges();

        //        // Retornar el ID del nuevo pedido
        //        return nuevoPedido.idPedido;
        //    }
        //}

    }
}