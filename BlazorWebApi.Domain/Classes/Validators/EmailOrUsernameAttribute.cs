using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Classes.Validators
{
    public class EmailOrUsernameAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // فرض کنید مقدار فیلد می‌تواند ایمیل یا نام کاربری باشد
            var input = value as string;

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult("این فیلد نمی‌تواند خالی باشد.");
            }

            // اعتبارسنجی ایمیل
            var isEmail = input.Contains("@") && input.Contains(".");
            // اعتبارسنجی نام کاربری
            var isUsername = input.Length >= 5; // شرط برای مثال: حداقل 5 کاراکتر

            if (!isEmail && !isUsername)
            {
                return new ValidationResult("باید ایمیل معتبر یا نام کاربری حداقل 5 کاراکتری وارد شود.");
            }

            return ValidationResult.Success;
        }
    }
}
