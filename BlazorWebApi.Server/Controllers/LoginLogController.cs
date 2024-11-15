using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginLogController : ControllerBase
    {
        private ILoginLogService _loginLogService;
        public LoginLogController(ILoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }

        [HttpGet]
        public IEnumerable<LoginLog> GetAll()
        {
            return _loginLogService.GetAll();
        }

        [HttpPost]
        public IActionResult AddLog(LoginLog loginLog)
        {
            if (_loginLogService.AddLog(loginLog))
            {
                return Ok(new { success = "success" });
            }
            else return BadRequest();
        }
    }
}
