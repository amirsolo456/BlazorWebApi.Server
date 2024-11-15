using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorWebApi.Infrastructure.Repository
{
    public class VillaService : IVillaService
    {
        private Data.ApplicationDbContext _context;
        public VillaService(Data.ApplicationDbContext Context)
        {
            _context = Context;
        }

        public bool AddVilla(Villa villa)
        {
            try
            {
                if (!_context.tblVillas.Where(c => c.ID == villa.ID).Any())
                    _context.tblVillas.Add(villa);
                else return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVilla(int VillaID)
        {
            try
            {
                if (_context.tblVillas.Where(c => c.ID == VillaID).Any())
                {
                    _context.tblVillas.Remove(_context.tblVillas.Where(c => c.ID == VillaID).FirstOrDefault());
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Villa> GetAllVillas(Expression<Func<Villa, bool>>? filter = null, string? IncludeProps = null)
        {
            IQueryable<Villa> query = _context.Set<Villa>();
            if (filter != null || IncludeProps != null)
            {
                if (filter != null)
                    query = query.Where(filter);

                if (!string.IsNullOrEmpty(IncludeProps))
                {
                    foreach (string item in IncludeProps.Split(new char[','], StringSplitOptions.RemoveEmptyEntries))
                    {
                        query.Include(item);
                    }
                }

                return query;
            }
            return query;
        }

        public IEnumerable<Villa> GetVillaByCategoryID(int Type, int CategoryID)
        {
            IQueryable<Villa> db = _context.tblVillas.AsQueryable();
            db = db.Where(c => c.VillaCategory1 == CategoryID || c.VillaCategory2 == CategoryID || c.VillaCategory3 == CategoryID 
            || c.VillaCategory4 == CategoryID || c.VillaCategory5 == CategoryID);
            db = db.Where(c => c.VillaType1 == Type || c.VillaType2 == Type || c.VillaType3 == Type || c.VillaType4 == Type || c.VillaType5 == Type);

            return db;
        }

        public Villa GetVillaByID(int ID)
        {

            return _context.tblVillas.Where(C => C.ID == ID).FirstOrDefault();

        }

        public IEnumerable<Villa> GetVillaByIDType(int Type)
        {
            IQueryable<Villa> db = _context.tblVillas.AsQueryable();
            db = db.Where(c => c.VillaType1 == Type || c.VillaType2 == Type || c.VillaType3 == Type || c.VillaType4 == Type || c.VillaType5 == Type);
            return db;
        }

        public IEnumerable<Villa> GetVillaByOffers()
        {
            return _context.tblVillas.Where(c => c.IsOffer == true);
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateVilla(Villa villa)
        {
            try
            {
                var item = _context.tblVillas.Find(villa.ID);
                if (item != null)
                {

                    item.Name = villa.Name;
                    item.CreateDate = villa.CreateDate ?? null;
                    item.Guestroom = villa.Guestroom;
                    item.Swimmingpool = villa.Swimmingpool;
                    item.Jacuzzi = villa.Jacuzzi;
                    item.Occupancy = villa.Occupancy;
                    item.UpdateDate = DateTime.Now;
                    item.Parking = villa.Parking;
                    item.Price = villa.Price;
                    item.Sqft = villa.Sqft;
                    item.Description = villa.Description ?? null;
                    item.ImageUrl = villa.ImageUrl ?? null;

                    _context.Update(item);
                }
                else return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int VillaCount()
        {
            return _context.tblVillas.Count();
        }

        public int VillaCountByName(string VillaName)
        {
            return _context.tblVillas.Where(c => c.Name.Trim().ToLower() == VillaName.Trim().ToLower()).Count();
        }
    }
}
