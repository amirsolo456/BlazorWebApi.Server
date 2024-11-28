using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCartsController : ControllerBase
    {
        private IGiftCartService _GiftCartService;
        public GiftCartsController(IGiftCartService GiftCartService)
        {
            _GiftCartService = GiftCartService;
        }

        [HttpGet("type/{Type}")]
        public IEnumerable<GiftCarts> getByType(int Type)
        {
            return _GiftCartService.GetByType(Type);
        }

        [HttpGet("status/{status}")]
        public IEnumerable<GiftCarts> getByStatus(GiftCardStatus status)
        {
            return _GiftCartService.GetByStatus(status);
        }

        [HttpGet("all/{TypeInRow},{CountInRow}")]
        public IEnumerable<GiftCarts> GetAll(int TypeInRow, int CountInRow)
        {
            return _GiftCartService.GetAll(TypeInRow, CountInRow);
        }

        [HttpGet("bycustomer/{id}")]
        public IEnumerable<GiftCarts> GetByCustomer(int CustomerID)
        {
            return _GiftCartService.GetByCustomer(CustomerID);
        }

        [HttpGet("getcart/{Type}")]
        public GiftCarts GetGiftCart(int Type)
        {
            return _GiftCartService.GetFirstGiftCart(Type);
        }

        [HttpPut("/{ID},{Balance}")]
        public IActionResult UpdateGiftCartBalance(int ID, decimal Balance)
        {
            if (_GiftCartService.UpdateGiftCartBalance(ID, Balance))
            {
                return Ok(new { Success = true });
            }
            return NotFound();
        }

        [HttpPut("Usage/{ID},{Balance},{Date}")]
        public IActionResult UpdateGiftCartUsage(int ID, decimal Usaged, string Date = "")
        {
            if (_GiftCartService.UpdateGiftCartUsage(ID, Usaged,Date))
            {
                return Ok(new { Success = true });
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddGiftCart(GiftCarts giftCart) 
        {
            if (_GiftCartService.AddGiftCart(giftCart))
            {
                return Ok(new { Success = true });
            }
            return NotFound();

        }

        [HttpDelete("/{ID}")]
        public IActionResult DeleteGiftCart(int ID)
        {
            if (_GiftCartService.DeleteGiftCart(ID))
            {
                return Ok(new { Success = true });
            }
            return NotFound();

        }
    }
}
