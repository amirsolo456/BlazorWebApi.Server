using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Customer"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }
        [ForeignKey("Villa"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal MabKol { get; set; }
        [Range(0,10)]
        public int PaymentMethod { get; set; }
        public int NumberGuests { get; set; }
        public bool IsReserved { get; set; } = false;

    }
}
