using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Shared;
using BlazorWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.InfraStructure.Repository
{
    public class MessagesService : IMessagesService
    {
        public int MyProperty { get; set; }
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
                _Context.SaveChanges();
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
            return _Context.tblMessages.ToList();

        }


        public IEnumerable<Messages> GetByCustomerID(int CustomerID)
        {
            int Type = 0;
            IQueryable<Messages> query = _Context.tblMessages.AsQueryable();
            return query.Where(c => c.Type == Type && c.IDSend == CustomerID).Select(m => new Messages
            {
                Message = m.Message,
                IDRecieve = m.IDRecieve,
                VillaID = m.VillaID,
                SabtDate = m.SabtDate,
                IDSend = m.IDSend,
                Type = Type,
            });
        }

        public Messages GetByID(int ID)
        {
            var item = _Context.tblMessages.Where(C => C.ID == ID).FirstOrDefault();
            if (item != null)
            {
                if (item.Type == 0)
                    item.SenderName = _Context.tblCustomers.Where(c => c.ID == item.IDSend).FirstOrDefault().FLName;
                else if (item.Type == 1)
                    item.SenderName = _Context.tblOwners.Where(c => c.ID == item.IDSend).FirstOrDefault().Name;
                else if (item.Type == 2)
                    item.SenderName = _Context.tblAdmin.Where(c => c.ID == item.IDSend).FirstOrDefault().FLName;
            }

            return item;
        }

        public IEnumerable<Messages> GetByOwnerID(int OwnerID)
        {
            int Type = 1;
            return _Context.tblMessages.Where(c => c.Type == Type && c.IDSend == OwnerID);
        }

        public IEnumerable<MessageReplays> GetCustomerMsgByReplay()
        {
            try
            {
                IQueryable<Messages> query = _Context.tblMessages.AsQueryable();
                var mainMessages = query.Where(c => c.IDGroup == 0).OrderBy(b => b.ID);

                IEnumerable<MessageReplays> messagesWithReplies = mainMessages
                .Select(mainMessage => new MessageReplays
                {
                    message = mainMessage,
                    replays = query
                    .Where(reply => reply.IDGroup == mainMessage.ID)
                     .OrderBy(reply => reply.ID)
                     .ToList()
                })
                    .ToList();

                foreach (MessageReplays msg in messagesWithReplies)
                {
                    if (msg.message.Type == 0)
                        msg.message.SenderName = _Context.tblCustomers.Where(c => c.ID == msg.message.IDSend).FirstOrDefault().FLName;
                    else if (msg.message.Type == 1)
                        msg.message.SenderName = _Context.tblOwners.Where(c => c.ID == msg.message.IDSend).FirstOrDefault().Name;
                    else if (msg.message.Type == 2)
                        msg.message.SenderName = _Context.tblAdmin.Where(c => c.ID == msg.message.IDSend).FirstOrDefault().FLName;

                    foreach (Messages replays in msg.replays)
                    {
                        if (replays.Type == 0)
                            replays.SenderName = _Context.tblCustomers.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                        else if (replays.Type == 1)
                            replays.SenderName = _Context.tblOwners.Where(c => c.ID == replays.IDSend).FirstOrDefault().Name;
                        else if (replays.Type == 2)
                            replays.SenderName = _Context.tblAdmin.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                    }

                }
                return messagesWithReplies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

        }

        public IEnumerable<MessageReplays> GetMssagesByCustomer()
        {
            IQueryable<Messages> query = _Context.tblMessages.AsQueryable();
            var mainMessages = query.Where(c => c.IDGroup == 0 && c.Type == 0).OrderBy(b => b.ID);

            IEnumerable<MessageReplays> messagesWithReplies = mainMessages
            .Select(mainMessage => new MessageReplays
            {
                message = mainMessage,
                replays = query
                .Where(reply => reply.IDGroup == mainMessage.ID)
                 .OrderBy(reply => reply.ID)
                 .ToList()
            })
                .ToList();

            foreach (MessageReplays msg in messagesWithReplies)
            {

                msg.message.SenderName = _Context.tblCustomers.Where(c => c.ID == msg.message.IDSend).FirstOrDefault().FLName;
                foreach (Messages replays in msg.replays)
                {
                    if (replays.Type == 0)
                        replays.SenderName = _Context.tblCustomers.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                    else if (replays.Type == 1)
                        replays.SenderName = _Context.tblOwners.Where(c => c.ID == replays.IDSend).FirstOrDefault().Name;
                    else if (replays.Type == 2)
                        replays.SenderName = _Context.tblAdmin.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                }

            }
            return messagesWithReplies;
        }

        public IEnumerable<MessageReplays> GetMssagesByOwner()
        {
            IQueryable<Messages> query = _Context.tblMessages.AsQueryable();
            var mainMessages = query.Where(c => c.IDGroup == 0 && c.Type == 1).OrderBy(b => b.ID);

            IEnumerable<MessageReplays> messagesWithReplies = mainMessages
            .Select(mainMessage => new MessageReplays
            {
                message = mainMessage,
                replays = query
                .Where(reply => reply.IDGroup == mainMessage.ID)
                 .OrderBy(reply => reply.ID)
                 .ToList()
            })
                .ToList();

            foreach (MessageReplays msg in messagesWithReplies)
            {
                msg.message.SenderName = _Context.tblOwners.Where(c => c.ID == msg.message.IDSend).FirstOrDefault().Name;
                foreach (Messages replays in msg.replays)
                {
                    if (replays.Type == 0)
                        replays.SenderName = _Context.tblCustomers.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                    else if (replays.Type == 1)
                        replays.SenderName = _Context.tblOwners.Where(c => c.ID == replays.IDSend).FirstOrDefault().Name;
                    else if (replays.Type == 2)
                        replays.SenderName = _Context.tblAdmin.Where(c => c.ID == replays.IDSend).FirstOrDefault().FLName;
                }
            }

            return messagesWithReplies;
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
                item.Type = messages.Type;
                _Context.tblMessages.Update(item);
                return true;
            }
            else return false;
        }
    }
}
