using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FLName { get; set; }
        [Range(0, 10)]
        public int Access { get; set; }
        public bool OwnerManage { get; set; } = false;

        public bool CustomerManage { get; set; } = false;
        public string SabtDate { get; set; }
        [Range(5,50)]
        public string UserName {  get; set; }
        [Range(5, 50)]
        public string Password { get; set; }
        public Admin()
        {
            
        }

        public Admin(int id, string Fame, string Lname, int access, bool OManager, bool CManager,string username,string password)
        {
            this.ID = id;
            this.FName = Fame;
            this.LName = Lname;
            this.FLName = FName + " " + Lname;
            this.Access = access;
            this.OwnerManage = OManager;
            this.CustomerManage = CManager;
            this.SabtDate = DateTime.Now.ToString();
            this.UserName = username;
            this.Password = password;
        }
    }
}
