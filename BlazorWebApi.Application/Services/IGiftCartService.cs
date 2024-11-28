using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IGiftCartService
    {
        public IEnumerable<GiftCarts> GetAll(int TypeInRow, int CountInRow);
        public IEnumerable<GiftCarts> GetByType(int Type);
        public IEnumerable<GiftCarts> GetByStatus(GiftCardStatus Status);
        public IEnumerable<GiftCarts> GetByCustomer(int CustomerID);
        public GiftCarts GetFirstGiftCart(int Type);
        public bool UpdateGiftCartBalance(int ID, decimal Balance);
        public bool UpdateGiftCartUsage(int ID, decimal Usaged,string Date ="");
        public bool AddGiftCart(GiftCarts giftCart);
        public bool DeleteGiftCart(int ID);

    }
}
