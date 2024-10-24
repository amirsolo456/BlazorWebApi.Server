using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCart> Get(Expression<Func<ShoppingCart,bool>> filter = null);
        bool AddToShoppingCart(ShoppingCart shoppingCart);
        bool DeleteShoppingCart(int ID);
        bool DeleteShoppingCart(ShoppingCart shoppingCart);
        bool UpdateShoppingCart(ShoppingCart shoppingCart);
        int Count(Expression<Func<ShoppingCart, bool>> filter=null);
        bool HasVilla(int VillaID, int CustomerID);
        void Save();
    }
}
