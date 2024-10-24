using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService _ShoppinCart;
        public ShoppingCartController(IShoppingCartService ShoppinCart)
        {
            _ShoppinCart = ShoppinCart;
        }

        [HttpGet]
        public IEnumerable<ShoppingCart> Get(Expression<Func<ShoppingCart, bool>> filter = null)
        {
            var res = _ShoppinCart.Get(filter);

            return res;
        }

        [HttpGet("count")]
        public int GetCount(Expression<Func<ShoppingCart, bool>> filter = null)
        {
            return _ShoppinCart.Count(filter);
        }

        [HttpGet("has-villa/{VillaID},{CustomerID}")]
        public bool HasVilla(int VillaID,int CustomerID)
        {
            return _ShoppinCart.HasVilla(VillaID,CustomerID);
        }

        [HttpPost]
        public IActionResult AddVilla(ShoppingCart shoppingCartAdd)
        {
            _ShoppinCart.AddToShoppingCart(shoppingCartAdd);
            return Ok(new { Success = true });
        }

        [HttpPut]
        public IActionResult UpdateVilla(ShoppingCart shoppingCartAdd)
        {
           if( _ShoppinCart.UpdateShoppingCart(shoppingCartAdd))
                return Ok(new { Success = true });
           else         return NotFound();        
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteVilla(int ID)
        {
            if (_ShoppinCart.DeleteShoppingCart(ID))
                return Ok(new { Success = true });
            else return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteVilla(ShoppingCart shoppingCartAdd)
        {
            if(_ShoppinCart.DeleteShoppingCart(shoppingCartAdd))
                return Ok(new { Success = true });
            else return NotFound();
        }
    }
}
