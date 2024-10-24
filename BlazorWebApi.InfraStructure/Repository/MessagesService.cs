using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.InfraStructure.Repository
{
    public class MessagesService : IMessagesService
    {
        private ApplicationDbContext _Context;
        public MessagesService(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public bool AddMessage(Messages messages)
        {
            if (!_Context.tblMessages.Any(c => c.ID == messages.ID))
            {
                _Context.tblMessages.Add(messages);

                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count()
        {
            return _Context.tblMessages.Count();
        }

        public bool DeleteMessage(int MessageID)
        {
            if (!_Context.tblMessages.Any(c => c.ID == MessageID))
            {
                return false;
            }
            else
            {
                _Context.tblMessages.Remove(_Context.tblMessages.FirstOrDefault(c => c.ID == MessageID));
                return true;
            }

        }

        public IEnumerable<Messages> GetAll()
        {
            return _Context.tblMessages;
        }

        public IEnumerable<Messages> GetByCustomerID(int CustomerID)
        {
            int Type = 0;
            return _Context.tblMessages.Where(c => c.Type == Type && c.IDSend == CustomerID);
        }

        public IEnumerable<Messages> GetByOwnerID(int OwnerID)
        {
            int Type = 1;
            return _Context.tblMessages.Where(c => c.Type == Type && c.IDSend == OwnerID);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public bool UpdateMessage(Messages messages)
        {
            var item = _Context.tblMessages.FirstOrDefault(c => c.ID == messages.ID);
            if (item != null)
            {
                item.Message = messages.Message;
                item.IDRecieve = messages.IDRecieve;
                item.VillaID = messages.VillaID;
                item.Type= messages.Type;
                _Context.tblMessages.Update(item);
                return true;
            }
            else return false;
        }
    }
}
