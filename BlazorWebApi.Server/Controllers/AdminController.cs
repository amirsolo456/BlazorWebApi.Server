using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.InfraStructure.Repository;
using BlazorWebApi.Server.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private  JwtTokenService _jwtTokenService;
        private IAdminService _AdminService;
        public AdminController(IAdminService AdminService, JwtTokenService jwtTokenService)
        {
            _AdminService = AdminService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        public IEnumerable<Admin> GetAll()
        {
            return _AdminService.GetAll();
        }

        [HttpGet("{User},{Pass}")]
        public Admin GetByUserPass(string User, string Pass)
        { 
            return _AdminService.GetByUserPassword(User, Pass);
        }

        [HttpGet("login/{User},{Pass}")]
        public IActionResult GetToken(string User, string Pass)
        {
            var admin = _AdminService.GetByUserPassword(User, Pass);
            if (admin != null)
            {
                var token = _jwtTokenService.GenerateJwtToken(admin.UserName, admin.Access.ToString(), 2.ToString());
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("نام کاربری یا رمز عبور اشتباه است.");
            }
        }

        [HttpPost("Create")]
        public IActionResult GetTokens(string User1, string Pass1)
        {
            var admin = _AdminService.GetByUserPassword(User1, Pass1);
            if (admin != null)
            {
                var token = _jwtTokenService.GenerateJwtToken(admin.UserName, admin.Access.ToString(), 2.ToString());
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("نام کاربری یا رمز عبور اشتباه است.");
            }
        }

        [HttpGet("{ID}")]
        public Admin GetByID(int ID)
        {

            return _AdminService.GetByID(ID);
        }
    }
}
