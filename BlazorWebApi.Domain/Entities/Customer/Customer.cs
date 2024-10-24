using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        [StringLength(30)]
        [DataType(DataType.Text)]
        public string? FLName { get; set; }
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string? PhNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "لطفا مقدار ایمیل را به درستی پرکنید.")]
        [StringLength(30)]
        public string? EmailAddres { get; set; }
        [StringLength(30)]
        public DateTime? SighnUpDate { get; set; }
        public IEnumerable<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
