using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.InfraStructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _AdminService;
        public AdminController(IAdminService AdminService)
        {
            _AdminService = AdminService;
        }

        [HttpGet]
        public IEnumerable<Admin> GetAll()
        {
            return _AdminService.GetAll();
        }

        [HttpGet("{ID}")]
        public Admin GetByID(int ID)
        {
            return _AdminService.GetByID(ID);
        }
    }
}
