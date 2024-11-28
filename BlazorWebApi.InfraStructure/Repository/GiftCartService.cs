using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.InfraStructure.Repository
{
    public class GiftCartService : IGiftCartService
    {
        private ApplicationDbContext _Context;
        public GiftCartService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public bool AddGiftCart(GiftCarts giftCart)
        {
            try
            {
                _Context.tblGiftCart.Add(giftCart);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;                
            }
        }

        public bool DeleteGiftCart(int ID)
        {
            if (_Context.tblGiftCart.Any(c => c.ID == ID))
            {
                _Context.tblGiftCart.Remove(_Context.tblGiftCart.Where(c => c.ID == ID).FirstOrDefault());
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<GiftCarts> GetAll(int TypeInRow,int CountInRow)
        {
            List<GiftCarts> result = new List<GiftCarts>();
            int numberOfEnumMembers = Enum.GetValues(typeof(GiftCardStatus)).Length;
            for (int i = 1; i <= numberOfEnumMembers; i++)
            {
                var items = _Context.tblGiftCart.Where(c => c.Type == i);

                if (items.Count() >= CountInRow)
                    result.AddRange(items.Take(CountInRow));
                else
                    result.AddRange(items.Take(items.Count()));
            }

            return result;
        }

        public IEnumerable<GiftCarts> GetByCustomer(int CustomerID)
        {
            return _Context.tblGiftCart.Where(c => c.ID == CustomerID);
        }

        public IEnumerable<GiftCarts> GetByStatus(GiftCardStatus Status)
        {
            return _Context.tblGiftCart.Where(c => c.Status == Status);
        }

        public IEnumerable<GiftCarts> GetByType(int Type)
        {
            return _Context.tblGiftCart.Where(c => c.Type == Type);
        }

        public GiftCarts GetFirstGiftCart(int Type)
        {
            return _Context.tblGiftCart.Where(c => c.Type == Type && c.CustomerID == 0).FirstOrDefault();
        }

        public bool UpdateGiftCartBalance(int ID, decimal Balance)
        {
            var item = _Context.tblGiftCart.Where(c => c.ID == ID).FirstOrDefault();
            if (item != null)
            {
                item.Balance = Balance;
                _Context.tblGiftCart.Update(item);
                _Context.SaveChanges();
                return true;
            }
            else return false;
        }


        public bool UpdateGiftCartUsage(int ID, decimal Usaged, string Date = "")
        {
            var item = _Context.tblGiftCart.Where(c => c.ID == ID).FirstOrDefault();
            if (item != null)
            {
                if (item.Balance >= Usaged)
                {
                    item.Balance = item.Balance - Usaged;
                    _Context.tblGiftCart.Update(item);
                    _Context.SaveChanges();
                }
                else return false;
                return true;
            }
            else return false;
        }
    }
}
