using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private IVillaService _VillaService;
        public VillaController(IVillaService villaService)
        {
            _VillaService = villaService;
        }

        [HttpGet]
        public IEnumerable<Villa> GetAllVilla(Expression<Func<Villa, bool>>? filter = null, string? IncludeProps = null)
        {
            return _VillaService.GetAllVillas(filter, IncludeProps).ToList();
        }

        [HttpGet("{ID}")]
        public Villa GetVillaByID(int ID)
        {
            return _VillaService.GetVillaByID(ID);
        }

        [HttpGet("total-page-count")]
        public int GetTotalPageCount()
        {
            return _VillaService.VillaCount();
        }


        [HttpPut]
        public void Update(Villa villa)
        {
            try
            {
                if ((villa != null && villa.ID > 0) || (villa != null && _VillaService.VillaCount() == 0))
                {
                    if (ModelState.IsValid)
                    {

                        var item = _VillaService.GetVillaByID(villa.ID);
                        if (item != null)
                        {
                            item.Sqft = villa.Sqft;
                            item.Name = villa.Name;
                            item.Description = villa.Description;
                            item.UpdateDate = DateTime.Now;
                            item.Price = villa.Price;
                            item.Swimmingpool = villa.Swimmingpool;
                            item.Parking = villa.Parking;
                            item.Jacuzzi = villa.Jacuzzi;
                            item.Guestroom = villa.Guestroom; 
                            _VillaService.UpdateVilla(item);
                            _VillaService.SaveChanges();
                        }
                        else
                        {
                            _VillaService.AddVilla(villa);
                            _VillaService.SaveChanges();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
            var item = _VillaService.GetVillaByID(ID);// فرض کنید آیتم با شناسه مشخص را دریافت می‌کنیم
            if (item != null)
            {
                _VillaService.DeleteVilla(ID);
                _VillaService.SaveChanges();
            }
        }

        [HttpPost("Create")]
        //[ValidateAntiForgeryToken]
        public void Create(Villa villa)
        {
            if (ModelState.IsValid)
            {
                villa.CreateDate = DateTime.Now;
                villa.UpdateDate = DateTime.Now;
                _VillaService.AddVilla(villa);  // اضافه کردن Villa جدید به دیتابیس
                _VillaService.SaveChanges();
            }
        }
    }
}
