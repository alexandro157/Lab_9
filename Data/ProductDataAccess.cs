using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class ProductDataAccess
    {
        private string connectionString = "Data Source=LAPTOP-5AIC5OBP\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=tecsup;Password=123456" ; 
        public List<Product> GetProductsByName(string productName)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string procedureName = "ListarProductosPorNombre";

                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Nombre", productName));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
