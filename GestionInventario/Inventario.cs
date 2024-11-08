using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                if (nuevoPrecio <= 0)
                    Console.WriteLine("El precio debe ser un número positivo.");
                else
                    producto.Precio = nuevoPrecio;
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);
        }

        public void ContarAgruparProductos()
        {
            var conteoPorRango = productos.GroupBy(p =>
                p.Precio < 100 ? "Menores a 100" : p.Precio <= 500 ? "Entre 100 y 500" : "Mayores a 500")
                .Select(g => new { Rango = g.Key, Conteo = g.Count() });

            foreach (var rango in conteoPorRango)
            {
                Console.WriteLine($"Rango: {rango.Rango}, Conteo: {rango.Conteo}");
            }
        }

        public void GenerarReporte()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            var precioPromedio = productos.Average(p => p.Precio);
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine($"\nNúmero total de productos: {productos.Count}");
            Console.WriteLine($"Precio promedio: {precioPromedio:c}");
            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre}, Precio: {productoMasCaro.Precio:c}");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre}, Precio: {productoMasBarato.Precio:c}");
        }
    }
}