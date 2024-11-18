using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAll(bool IncludeProp =false);
        public Customer GetByID(int id, bool IncludeProp = false);
        public Customer GetByUserPass(string User, string Password);
        public int GetCount();

        public bool AddCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);
    }
}
