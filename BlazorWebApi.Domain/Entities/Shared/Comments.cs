using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities.Shared
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "شناسه ویلا")]
        public int VillaID { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "امتیاز باید بین 1 تا 10 باشد.")]
        [Display(Name = "امتیاز")]
        public int Score { get; set; }
        [Required(ErrorMessage = "نام کاربر الزامی است.")]
        [StringLength(50, ErrorMessage = "نام کاربر نمی‌تواند بیشتر از 50 کاراکتر باشد.")]
        [Display(Name = "نام کاربر")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست.")]
        [StringLength(100, ErrorMessage = "ایمیل نمی‌تواند بیشتر از 100 کاراکتر باشد.")]
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "متن کامنت نمی‌تواند خالی باشد.")]
        [StringLength(500, ErrorMessage = "متن کامنت نمی‌تواند بیشتر از 500 کاراکتر باشد.")]
        [Display(Name = "متن کامنت")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "تاریخ ثبت")]
        [StringLength(30, ErrorMessage = "تاریخ ثبت را به درستی وارد نمایید")]
        [DataType(DataType.DateTime)]
        public string CreatedAt { get; set; }

        [ForeignKey(nameof(VillaID))]
        public Villa Villa { get; set; } // ارتباط با مدل Villa
    }
}
