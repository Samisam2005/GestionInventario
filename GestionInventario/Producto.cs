using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestionInventario
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacío.");
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser un número positivo.");

            Nombre = nombre;
            Precio = precio;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:c}");
        }
    }
}