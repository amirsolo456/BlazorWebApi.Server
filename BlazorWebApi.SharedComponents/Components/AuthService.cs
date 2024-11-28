using Blazored.LocalStorage;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorWebApi.SharedComponents
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;
        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            Console.WriteLine("_localStorage");
        }
        public AuthService()
        {
                
        }

        // بررسی وضعیت احراز هویت
        public async Task<bool> IsAuthenticated()
        {
            try
            {
                string? token = await _localStorage.GetItemAsync<string?>("authToken");
                Console.WriteLine(token?? " ");
                return !string.IsNullOrEmpty(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا در چک کردن توکن"+ex.Message);
                return false;

            }

        }

        // ذخیره توکن JWT در LocalStorage
        public async Task SetAuthenticationToken(string token)
        {
            await _localStorage.SetItemAsync("authToken", token);
        }

        // حذف توکن JWT (خروج)
        public async Task RemoveAuthenticationToken()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        // دریافت توکن JWT از LocalStorage
        public async Task<string> GetAuthenticationToken()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }

        public bool Validator(string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // اگر می‌خواهید اعتبارسنجی issuer انجام شود، این را true کنید
                    ValidateAudience = false, // اگر می‌خواهید اعتبارسنجی audience انجام شود، این را true کنید
                    ValidateLifetime = true, // چک کردن تاریخ انقضا
                    ClockSkew = TimeSpan.Zero, // تنظیم محدودیت زمانی برای تاریخ انقضا
                    IssuerSigningKey = new SymmetricSecurityKey(key) // کلید امنیتی
                };

                // اعتبارسنجی توکن
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                return validatedToken != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("توکن معتبر نیست: " + ex.Message);
                return false;
            }
        }

        public ClaimsPrincipal ExtractClaims(string token,string secretKey)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // اگر می‌خواهید اعتبارسنجی issuer انجام شود، این را true کنید
                    ValidateAudience = false, // اگر می‌خواهید اعتبارسنجی audience انجام شود، این را true کنید
                    ValidateLifetime = true, // چک کردن تاریخ انقضا
                    ClockSkew = TimeSpan.Zero, // تنظیم محدودیت زمانی برای تاریخ انقضا
                    IssuerSigningKey = new SymmetricSecurityKey(key) // کلید امنیتی
                };

                // اعتبارسنجی توکن
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (principal != null)
                {
                    Console.WriteLine(principal.FindFirst("sub")?.Value);
                    return principal;
                }
                else
                {
                    Console.WriteLine("null");
                    return null;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
