using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorWebApi.Infrastructure.Repository
{
    public class ShoppingCartService : IShoppingCartService
    {
        private BlazorWebApi.Infrastructure.Data.ApplicationDbContext _context;

        public ShoppingCartService(BlazorWebApi.Infrastructure.Data.ApplicationDbContext context)
        {
            this._context = context;
        }

        public bool AddToShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                shoppingCart.CreateDate = shoppingCart.UpdateDate = DateTime.Now;
                _context.tblShoppingCart.Add(shoppingCart);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int Count(Expression<Func<ShoppingCart, bool>> filter = null)
        {
            return Get(filter).ToList().Count;
        }

        public bool DeleteShoppingCart(int ID)
        {
            try
            {
                if (_context.tblShoppingCart.Any(c => c.ID == ID))
                {
                    _context.tblShoppingCart.Remove(_context.tblShoppingCart.Where(c => c.ID == ID).FirstOrDefault());
                    _context.SaveChanges();
                    return true;
                }
                else return false;
                 
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                if (_context.tblShoppingCart.Any(c => c.ID == shoppingCart.ID))
                {
                    _context.tblShoppingCart.Remove(shoppingCart);
                    return true;
                }
                else return false;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<ShoppingCart> Get(Expression<Func<ShoppingCart, bool>> filter = null)
        {
            IQueryable<ShoppingCart> query = _context.tblShoppingCart.AsQueryable();
            if (filter != null)
                return query.Where(filter);
            else
                return query;
        }

        public bool HasVilla(int VillaID, int CustomerID)
        {
            IQueryable<ShoppingCart> query = _context.tblShoppingCart.AsQueryable();
            return query.Where(C => C.VillaID == VillaID && C.CustomerID == CustomerID).Any();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            ShoppingCart item = _context.tblShoppingCart.FirstOrDefault( c => c.ID == shoppingCart.ID);
            if (item == null)
            {
                item.Quantity = shoppingCart.Quantity;
                item.UpdateDate = DateTime.Now;
                item.VillaID = shoppingCart.VillaID;
                _context.tblShoppingCart.Add(item);
                return true;
            }
            else return false;
        }
    }
}
