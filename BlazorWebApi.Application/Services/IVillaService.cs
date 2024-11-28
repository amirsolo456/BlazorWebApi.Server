using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IVillaService
    {
        public IEnumerable<Villa> GetAllVillas(Expression<Func<Villa,bool>>? filter = null ,string? IncludeProps=null);
        public Villa GetVillaByID(int ID);
        public IEnumerable<Villa> GetVillaByOffers();
        public IEnumerable<Villa> GetVillaByTakhfif();
        public IEnumerable<Villa> GetVillaByBest();
        public IEnumerable<Villa> GetVillaByIDType(int Type);
        public IEnumerable<Villa> GetVillaByCategoryID(int Type,int CategoryID);
        public IEnumerable<Villa> GetNotReservedVillas();
        public int VillaCount ();
        public int VillaCountByName(string VillaName);
        public bool AddVilla(Villa villa);
        public bool UpdateVilla(Villa villa);
        public bool DeleteVilla(int VillaID);
        public bool SaveChanges();

    }
}
