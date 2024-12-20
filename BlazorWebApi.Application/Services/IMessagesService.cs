﻿using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Shared;
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
        public IEnumerable<MessageReplays> GetMssagesByOwner();
        public IEnumerable<MessageReplays> GetMssagesByCustomer();

        public IEnumerable<MessageReplays> GetCustomerMsgByReplay();
        public IEnumerable<Messages> GetByCustomerID(int CustomerID);
        public IEnumerable<Messages> GetByOwnerID(int OwnerID);
        public Messages GetByID(int ID);
        public int Count();
        public bool AddMessage(Messages messages);
        public bool UpdateMessage(Messages messages);
        public bool DeleteMessage(int MessageID);
        public void SaveChanges();
    }
}
