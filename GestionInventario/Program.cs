using System;

namespace GestionInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("BIENVENIDO AL SISTEMA DE GESTION DE INVENTARIO.");
            Console.WriteLine("-----------------------------------------------");

            Console.Write("\nCuántos productos desea ingresar?\n");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                try
                {
                    Producto producto = new Producto(nombre, precio);
                    inventario.AgregarProducto(producto);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    i--; // Reintentar el ingreso del producto
                    continue;
                }
            }

            Console.WriteLine("\nIngrese el precio mínimo para filtrar los productos: ");
            decimal precioMinimo = decimal.Parse(Console.ReadLine());
            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }

            Console.WriteLine("\nFunción de actualización de precio.");
            Console.Write("Ingrese el nombre del producto a actualizar: ");
            string nombreProductoActualizar = Console.ReadLine();
            Console.Write("Ingrese el nuevo precio: ");
            decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
            inventario.ActualizarPrecio(nombreProductoActualizar, nuevoPrecio);

            Console.WriteLine("\nFunción de eliminación de producto.");
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            string nombreProductoEliminar = Console.ReadLine();
            inventario.EliminarProducto(nombreProductoEliminar);

            Console.WriteLine("\nConteo y agrupación de productos:");
            inventario.ContarAgruparProductos();

            Console.WriteLine("\nReporte resumido del inventario:");
            inventario.GenerarReporte();
        }
    }
}