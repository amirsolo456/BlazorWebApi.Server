using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessagesService _MessagesService;
        public MessagesController(IMessagesService MessagesService)
        {
            _MessagesService = MessagesService;
        }

        [HttpGet]
        public IEnumerable<Messages> GetAll()
        {
            return _MessagesService.GetAll();
        }

        [HttpGet("ByID/{id}")]
        public Messages GetByID(int id)
        {
            return _MessagesService.GetByID(id);
        }

        [HttpGet("OwnerRep")]
        public IEnumerable<MessageReplays> GetOwnersMessages()
        {
            return _MessagesService.GetMssagesByOwner();
        }

        [HttpGet("CustomerRep")]
        public IEnumerable<MessageReplays> GetCustomersMessages()
        {
            return _MessagesService.GetCustomerMsgByReplay();
        }

        [HttpGet("Customer/{CustomerID}")]
        public IEnumerable<Messages> getByCustomerID(int CustomerID)
        {
            return _MessagesService.GetByCustomerID(CustomerID);

        }

        [HttpGet("Owner/{OwnerID}")]
        public IEnumerable<Messages> getByOwnerID(int OwnerID)
        {
            return _MessagesService.GetByOwnerID(OwnerID);

        }

        [HttpGet("count")]
        public int Getcount()
        {
            return _MessagesService.Count();

        }

        [HttpPost]
        public IActionResult Add(Messages messages)
        {
            try
            {
                if (_MessagesService.AddMessage(messages))
                {
                    _MessagesService.SaveChanges();
                    return Ok(new { Success = true });
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                 return BadRequest(ex);
            }

        }

        [HttpPut]
        public IActionResult Update(Messages messages)
        {
            try
            {
                if (_MessagesService.UpdateMessage(messages))
                {
                    _MessagesService.SaveChanges();
                    return Ok(new { Success = true });
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_MessagesService.DeleteMessage(id))
                {
                    _MessagesService.SaveChanges();
                    return Ok(new { Success = true });
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
