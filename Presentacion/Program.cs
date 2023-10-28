using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;
using Buisnes;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre del producto a buscar: ");
            string productName = Console.ReadLine();

            ProductBusiness productBusiness = new ProductBusiness(); // Crea una instancia de la capa de negocios
            List<Product> products = productBusiness.ListProductsByName(productName); // Utiliza la función de la capa de negocios

            if (products.Count == 0)
            {
                Console.WriteLine("No se encontraron productos con ese nombre.");
            }
            else
            {
                Console.WriteLine("Productos encontrados:");
                foreach (Product product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Nombre: {product.Name}, Precio: {product.Price:C}, Stock: {product.Stock}");
                }
            }
        }
    }
}
