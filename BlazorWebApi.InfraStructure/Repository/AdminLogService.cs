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
    public class AdminLogService : IAdminLogService
    {
        private ApplicationDbContext _Context;
        public AdminLogService(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public bool AddLog(AdminLog log)
        {
            try
            {
                if (log != null && !_Context.tblAdminLog.Where(c => c.Id == log.Id).Any())
                {
                    _Context.tblAdminLog.Add(log);
                    _Context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLog(int id)
        {

            try
            {
                _Context.tblAdminLog.Remove(_Context.tblAdminLog.Where(c => c.Id == id).FirstOrDefault());
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<AdminLog> GetAll()
        {
            return _Context.tblAdminLog.Include(c => c.Admin);
        }

        public IEnumerable<AdminLog> GetByAdminID(int adminID)
        {
            return _Context.tblAdminLog.Include(c => c.Admin).Where(b => b.AdminId == adminID);
        }

        public AdminLog GetByID(int id)
        {
            return _Context.tblAdminLog.Include(c => c.Admin).Where(b => b.Id == id).FirstOrDefault();
        }

        public int GetCount()
        {
            return _Context.tblAdminLog.Count();
        }

        public bool SaveChanges()
        {
            try
            {
                _Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLog(AdminLog log)
        {
            try
            {
                if(log!= null && _Context.tblAdminLog.Where(c=>c.Id == log.Id).Any())
                {
                    var item = _Context.tblAdminLog.Where(c => c.Id == log.Id).FirstOrDefault();
                    item.LoginTime = log.LoginTime;
                    item.LogoutTime= log.LogoutTime;
                    item.IPAddress = log.IPAddress;
                    item.AdminId = log.AdminId;
                    _Context.tblAdminLog.Update(item);
                    _Context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
