using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities.Owner
{
    public class VillaCategory
    {
        [Key]
        public int ID { get; set; }
        public int IDType { get; set; }
        [MaxLength(50)]
        public string TypeName { get; set; }
        public int CategoryID { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
