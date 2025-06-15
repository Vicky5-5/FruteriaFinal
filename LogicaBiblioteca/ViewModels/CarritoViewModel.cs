using System.Collections.Generic;
using System.Linq;
using LogicaBiblioteca.Managers;
using LogicaBiblioteca.Modelos;

namespace Fruteria.ViewModels
{
    public class CarritoViewModel
    {
        public int idCarrito { get; set; }
        public int idProducto { get; set; }
        public int CantidadCompra { get; set; }
        public decimal totalProductos { get; set; }
        public ProductosViewModel oProducto { get; set; }

        public CarritoViewModel(Carrito carro)
        {
            this.idCarrito = carro.idCarrito;
            this.idProducto = carro.idProducto;
            this.CantidadCompra = carro.CantidadCompra;
            this.totalProductos = carro.totalProductos;
            this.oProducto = new ProductosViewModel(carro.oProducto);
        }

        public static List<CarritoViewModel> ObtenerCarrito()
        {
            return CarritoManager.ListaCarrito().Select(c => new CarritoViewModel(c)).ToList();
        }


    }
}