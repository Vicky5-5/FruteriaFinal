using LogicaBiblioteca.Contexto;
using LogicaBiblioteca.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace LogicaBiblioteca.Modelos
{
    public class Carrito
    {
        [Key]
        public int idProducto { get; set; }
        public int idCarrito { get; set; }
        public int idUsuario { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadCompra { get; set; } = 0;
        public decimal totalProductos { get; set; } //Precio con la oferta
        public int idCarr { get; set; }
        //public decimal OfertaPr {  get; set; }
        public Productos oProducto { get; set; }
        public virtual Usuario oUsuario { get; set; }


    }
}