using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IAdminService
    {
        public IEnumerable<Admin> GetAll();
        public Admin GetByID(int ID);
        public Admin GetByUserPassword(string Username, string Password);
        public int GetCount();

    }
}
