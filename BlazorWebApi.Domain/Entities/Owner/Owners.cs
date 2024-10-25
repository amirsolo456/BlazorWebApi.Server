using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Owners
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string PhNumber { get; set; }
        [MaxLength(20)]
        public string SabtDate { get; set; }
        [Range(0,10)]
        public double Score { get; set; }
    }
}
