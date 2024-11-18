using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet("{Includeprop}")]
        public IEnumerable<Customer> Get(bool Includeprop = false)
        {
            return _CustomerService.GetAll(Includeprop);
        }

        [HttpGet("{ID},{Includeprop}")]
        public Customer GetByID(int ID, bool Includeprop = false)
        {
            return _CustomerService.GetByID(ID, Includeprop);
        }

        [HttpGet("userlogin/{user},{pass}")]
        public Customer GetByUserPass(string user,string pass)
        {
            return _CustomerService.GetByUserPass(user, pass);
        }

        [HttpGet]
        public int GetCount()
        {
            return _CustomerService.GetCount();
        }
    }
}
