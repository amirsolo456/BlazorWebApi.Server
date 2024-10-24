using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IMessagesService
    {
        public IEnumerable<Messages> GetAll();
        public IEnumerable<Messages> GetByCustomerID(int CustomerID);
        public IEnumerable<Messages> GetByOwnerID(int OwnerID);
        public int Count();
        public bool AddMessage(Messages messages);
        public bool UpdateMessage(Messages messages);
        public bool DeleteMessage(int MessageID);
        public void SaveChanges();
    } 
}
