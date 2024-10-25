using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerService _OwnerService;
        public OwnerController(IOwnerService OwnerService)
        {
            _OwnerService = OwnerService;
        }

        [HttpGet]
        public IEnumerable<Owners> GetAll()
        {
            return _OwnerService.GetAll();
        }

        [HttpGet("{ID}")]
        public Owners GetByID(int ID)
        {
            return _OwnerService.GetByID(ID);
        }
    }
}
