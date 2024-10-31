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
    public class OwnerService : IOwnerService
    {
        public int MyProperty { get; set; }
        private ApplicationDbContext _Context;
        public OwnerService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<Owners> GetAll()
        {
           return _Context.tblOwners.ToList();
        }

        public Owners GetByID(int ID)
        {
            return _Context.tblOwners.Where(c => c.ID == ID).FirstOrDefault();
        }

        public int GetCount()
        {
            return _Context.tblOwners.Count();

        }
    }
}
