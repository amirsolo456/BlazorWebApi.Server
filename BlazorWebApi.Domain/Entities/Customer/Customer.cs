using BlazorWebApi.Domain.Classes.Validators;
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
        //[EmailAddress]
        [Required(ErrorMessage = "لطفا مقدار ایمیل را به درستی پرکنید.")]
        [StringLength(30)]
        [EmailOrUsername]
        public string? EmailAddres { get; set; }
        [StringLength(30)]
        public DateTime? SighnUpDate { get; set; }
        public IEnumerable<ShoppingCart>? ShoppingCarts { get; set; }

        [Required(ErrorMessage = "پسورد الزامی است.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "پسورد باید حداقل 8 و حداکثر 100 کاراکتر باشد.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
         ErrorMessage = "پسورد باید حداقل شامل یک حرف بزرگ، یک حرف کوچک، یک عدد و یک کاراکتر خاص باشد.")]
        public string Password { get; set; } = "amirsol";

        [Required(ErrorMessage = "یوزرنیم الزامی است.")]
        [StringLength(50, ErrorMessage = "یوزرنیم نمی‌تواند بیشتر از 50 کاراکتر باشد.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "یوزرنیم فقط می‌تواند شامل حروف، اعداد و خط زیر (_) باشد.")]
        public string Username { get; set; } = "amirsol";
    }
}
