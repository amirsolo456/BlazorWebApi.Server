using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        [ForeignKey("Villa"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaID { get; set; }
        [ForeignKey("Customer"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }
        [MaxLength(50)]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [MaxLength(50)]
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        [Range(0, 1000000)]
        [Required]
        public double Quantity { get; set; }
        public Villa? villa { get; set; }
    }
}
