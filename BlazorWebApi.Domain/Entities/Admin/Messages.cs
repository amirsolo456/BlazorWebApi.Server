using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Messages
    {
        [Key]
        public int ID { get; set; }
        [Range(0,10)]
        public int Type { get; set; }
        public int IDSend { get; set; }
        public int? IDRecieve { get; set; }
        [ForeignKey("Villa"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? VillaID { get; set; }
        public string Message { get; set; }
        public string SabtDate {  get; set; }
        //[ForeignKey("Customer")]
        //public int? CustomerId { get; set; }
        //[ForeignKey("Owners")]
        //public int? OwnerId { get; set; }
        //[ForeignKey("Admin")]
        //public int? AdminId { get; set; }
        //public virtual Customer? customer { get; set; } = null;
        //public virtual Owners? owners { get; set; } = null;
        //public virtual Admin? admin { get; set; } = null;
        public  string TypeName
        {
            get
            {
                if (Type == 0) return "مشتری";
                else if (Type == 1) return "مالک";
                else return "ادمین";
            }
        }
    }
}
