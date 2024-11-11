using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class AdminLog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }

        public Admin Admin { get; set; }

        public DateTime LoginTime { get; set; } = DateTime.UtcNow;
        public DateTime? LogoutTime { get; set; }

        [MaxLength(45)]
        public string IPAddress { get; set; }
    }
}
