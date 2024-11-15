using BlazorWebApi.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Application.Services
{
    public interface ILoginLogService
    {
        public IEnumerable<LoginLog> GetAll();
        public IEnumerable<LoginLog> GetAdminByID(int UserID);
        public IEnumerable<LoginLog> GetCustomerByID(int UserID);
        public IEnumerable<LoginLog> GetOwnerByID(int UserID);
        public LoginLog GetByID(int ID);
        public bool AddLog(LoginLog loginLog);
        public bool UpdateLog(LoginLog loginLog);
        public bool DeleteLog(int ID);
    }
}
