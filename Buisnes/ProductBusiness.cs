using Microsoft.Data.SqlClient;
using System.Data;
using Entity;
using Data;
using System.Net.Sockets;

namespace Buisnes
{
    public class ProductBusiness
    {
        private ProductDataAccess dataAccess; 

        public ProductBusiness()
        {
            dataAccess = new ProductDataAccess(); 
        }

        public List<Product> ListProductsByName(string productName)
        {
           
            List<Product> products = dataAccess.GetProductsByName(productName);

            return products;
        }

        public List<Client> GetAll()
        {
            //List<Client> result = new List<Client>();
            //DClient dClient = new DClient();
            //var client = dClient.ListarClientes();

            //foreach (var item in client)
            //{
            //    result.Add(item);

            //}
            return null;
        }
    }
}