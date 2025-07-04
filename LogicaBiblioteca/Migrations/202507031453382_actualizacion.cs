namespace LogicaBiblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidos", "oProductos_idProducto", "dbo.Productos");
            DropIndex("dbo.Pedidos", new[] { "oProductos_idProducto" });
            DropColumn("dbo.Pedidos", "oProductos_idProducto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidos", "oProductos_idProducto", c => c.Int());
            CreateIndex("dbo.Pedidos", "oProductos_idProducto");
            AddForeignKey("dbo.Pedidos", "oProductos_idProducto", "dbo.Productos", "idProducto");
        }
    }
}
