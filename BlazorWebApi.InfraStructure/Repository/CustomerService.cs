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
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _Context;
        public CustomerService(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                _Context.tblCustomers.Add(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                _Context.tblCustomers.Remove(_Context.tblCustomers.Where(c => c.ID == id).First());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Customer> GetAll(bool IncludeProp = false)
        {
            IQueryable<Customer> query = _Context.tblCustomers.AsQueryable();
            if (IncludeProp)
                return query.Include(c => c.ShoppingCarts).ThenInclude(f => f.villa);
            else return query;
        }

        public Customer GetByID(int id, bool IncludeProp = false)
        {
            IQueryable<Customer> query = _Context.tblCustomers.AsQueryable();
            if (IncludeProp)
                return query.Include(c => c.ShoppingCarts).ThenInclude(f => f.villa).Where(d => d.ID == id).FirstOrDefault();
            else return query.Where(c => c.ID == id).FirstOrDefault();
        }

        public Customer GetByUserPass(string User, string Password)
        {
          var item = _Context.tblCustomers.FirstOrDefault(c => (c.Username.ToLower() == User.ToLower() || c.EmailAddres.ToLower() == User.ToLower()) && c.Password == Password);
            if (item != null)
            {
                return item;
            }
            else return null;
        }

        public int GetCount()
        {
            return _Context.tblCustomers.Count();
        }

        public bool UpdateCustomer(Customer customer)
        {
           var item = _Context.tblCustomers.FirstOrDefault(c => c.ID == customer.ID);
            if (item != null)
            {
                item.PhNumber = customer.PhNumber;
                item.FLName = customer.FLName;
                item.EmailAddres = customer.EmailAddres;
                _Context.tblCustomers.Update(item);
                return true;
            }
            else return false;
        }
    }
}
