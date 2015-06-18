using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetTodaysDealsProducts();
        IEnumerable<Product> GetProductsForCategory(int subcategoryId);
        IEnumerable<Product> GetProducts();
        Product GetProduct(string productNumber);
    
    }
}
