using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities.Shared
{
    public class LoginLog
    {
        [Key]
        public int Id { get; set; }
        public bool IsLogin { get; set; }
        public int UserID { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsCustomer { get; set; }

        public bool IsOwner { get; set; }
        

        public string LoginTime { get; set; }
        public string? LogoutTime { get; set; }

        [MaxLength(45)]
        public string IPAddress { get; set; }
    }
}
