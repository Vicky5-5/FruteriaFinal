namespace LogicaBiblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorregirRelacionCarrito : DbMigration
    {
        public override void Up()
        {
            // 1. Eliminar la FK e índice si existen
            DropForeignKey("dbo.Carrito", "oProducto_idProducto", "dbo.Productos");
            DropIndex("dbo.Carrito", new[] { "oProducto_idProducto" });

            // 2. ELIMINAR la clave primaria actual, que depende de idProducto
            DropPrimaryKey("dbo.Carrito");

            // 3. Ya podemos eliminar la columna idProducto
            DropColumn("dbo.Carrito", "idProducto");

            // 4. Agregar la columna idProducto de nuevo, con las nuevas propiedades
            AddColumn("dbo.Carrito", "idProducto", c => c.Int(nullable: false));

            // 5. Cambiar idCarrito para que sea PK y autoincremental
            AlterColumn("dbo.Carrito", "idCarrito", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carrito", "idCarrito");

            // 6. Crear índice y FK para idProducto
            CreateIndex("dbo.Carrito", "idProducto");
            AddForeignKey("dbo.Carrito", "idProducto", "dbo.Productos", "idProducto", cascadeDelete: true);
        }



        public override void Down()
        {
            // 1. Quitar FK e índice nuevos
            DropForeignKey("dbo.Carrito", "idProducto", "dbo.Productos");
            DropIndex("dbo.Carrito", new[] { "idProducto" });

            // 2. Quitar clave primaria actual
            DropPrimaryKey("dbo.Carrito");

            // 3. Cambiar idCarrito para quitar identity (autoincremental)
            AlterColumn("dbo.Carrito", "idCarrito", c => c.Int(nullable: false));

            // 4. Renombrar columna idProducto a oProducto_idProducto
            RenameColumn("dbo.Carrito", "idProducto", "oProducto_idProducto");

            // 5. Agregar de nuevo la columna idProducto original, con identity (autoincremental)
            AddColumn("dbo.Carrito", "idProducto", c => c.Int(nullable: false, identity: true));

            // 6. Poner la clave primaria en la columna idProducto original
            AddPrimaryKey("dbo.Carrito", "idProducto");

            // 7. Crear índice y FK antiguos
            CreateIndex("dbo.Carrito", "oProducto_idProducto");
            AddForeignKey("dbo.Carrito", "oProducto_idProducto", "dbo.Productos", "idProducto");
        }

    }
}
