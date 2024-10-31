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
        [Range(0, 10)]
        public int IDGroup { get; set; }
        public int Type { get; set; }
        public int IDSend { get; set; }
        public int? IDRecieve { get; set; }
        public int? TypeRecieve { get; set; }
        [ForeignKey("Villa"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? VillaID { get; set; }
        public string Message { get; set; }
        public string SabtDate { get; set; }
        [NotMapped]
        public string SenderName { get; set; }
        public bool OnRead { get; set; } = false;
        public string TypeName
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
