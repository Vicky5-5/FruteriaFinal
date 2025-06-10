using LogicaBiblioteca.Managers;
using LogicaBiblioteca.Modelos;
using System.Collections.Generic;

namespace Fruteria.ViewModels
{
    public class CarritoViewModel
    {
        public int idProducto { get; set; }
        public int idCarrito { get; set; }

        public string NombreProducto { get; set; }
        public int CantidadCompra { get; set; }
        public decimal totalProductos { get; set; } //Precio con la oferta
        public int idCarr { get; set; }
        //public decimal OfertaPr {  get; set; }
        public Productos oProducto { get; set; }
        public virtual Usuario oUsuario { get; set; }


        public CarritoViewModel(Carrito carro)
        {
            this.idCarrito = carro.idCarrito;
            this.oProducto.idProducto = carro.idProducto;
            this.oProducto.NombreProducto = carro.NombreProducto;
            this.CantidadCompra = carro.CantidadCompra;
            this.totalProductos = carro.totalProductos;
            //this.idCarr = guardcarroado.idCarr;
        }
        public static List<ProductosViewModel> Catalogo()
        {
            var listar = ProductosManager.ListarProductos();
            List<ProductosViewModel> lista = new List<ProductosViewModel>();
            foreach (var item in listar)
            {
                ProductosViewModel model = new ProductosViewModel(item);

                lista.Add(model);

            }
            return lista;

        }
        public CarritoViewModel AddProducto(Productos carrito)
        {
            
            //var guardado = CarritoManager.AddCart(carrito);

           



            return null;
        }
    }
}