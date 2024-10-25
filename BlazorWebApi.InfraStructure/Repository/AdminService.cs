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
    public class AdminService : IAdminService
    {
        private ApplicationDbContext _Context;
        public AdminService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return _Context.tblAdmin.ToList();
        }

        public Admin GetByID(int ID)
        {
            return _Context.tblAdmin.Where( c => c.ID == ID).FirstOrDefault();
        }

        public int GetCount()
        {
            return _Context.tblAdmin.Count();
        }
    }
}
