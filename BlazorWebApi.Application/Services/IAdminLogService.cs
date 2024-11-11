using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface IAdminLogService
    {
        public IEnumerable<AdminLog> GetAll();
        public IEnumerable<AdminLog> GetByAdminID(int adminID);
        public AdminLog GetByID(int id);
        public int GetCount();
        public bool AddLog(AdminLog log);
        public bool UpdateLog(AdminLog log);
        public bool DeleteLog(int id);
        public bool SaveChanges();
    }
}
