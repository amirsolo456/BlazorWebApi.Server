using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentsService _commentservice;
        public CommentsController(ICommentsService commentservice)
        {
            _commentservice = commentservice;
        }

        [HttpGet("forvilla/{VillaID}")]
        public IEnumerable<Comments> GetCommentForVilla(int VillaID)
        {
           return _commentservice.getCommentsForVilla(VillaID);
        }
    }
}
