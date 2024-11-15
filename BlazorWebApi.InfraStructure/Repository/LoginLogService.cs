using BlazorWebApi.Application.Services;
using BlazorWebApi.Domain.Entities.Shared;
using BlazorWebApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.InfraStructure.Repository
{
    public class LoginLogService : ILoginLogService
    {
        private ApplicationDbContext _dbcontext;
        public LoginLogService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool AddLog(LoginLog loginLog)
        {
            _dbcontext.tblLoginLog.Add(loginLog);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool DeleteLog(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginLog> GetAdminByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoginLog GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginLog> GetCustomerByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginLog> GetOwnerByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLog(LoginLog loginLog)
        {
            throw new NotImplementedException();
        }
    }
}
