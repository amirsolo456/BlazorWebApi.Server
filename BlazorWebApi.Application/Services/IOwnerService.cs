using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IOwnerService
    {
        public IEnumerable<Owners> GetAll();
        public Owners GetByID(int ID);
        public int GetCount();

    }
}
