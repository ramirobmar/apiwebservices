using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IShoppingCartRepository
    {
       
        ShoppingCart GetById(string shoppingCartId);
        bool Delete(string userId);
        void AddProductToCart(string shoppingCartId, Product product);
        bool RemoveProductFromCart(string shoppingCartId, string productId);
        bool RemoveItemFromCart(ShoppingCart shoppingCart, string itemId);
       
    }
}
