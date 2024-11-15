using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorWebApi.Server.Properties
{
    public class JwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        // وابستگی به IOptions<JwtSettings>
        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateJwtToken(string username, string accessLevel, string usertype)
        {
            // 1. ایجاد Claims (اطلاعات توکن)
            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name, username),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            //};

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, usertype), // نقش کاربر
                new Claim("AccessLevel", accessLevel), // سطح دسترسی سفارشی
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // 2. ساخت SecurityKey از SecretKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            //string base64Secret = Convert.ToBase64String(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            // 3. تنظیم توکن
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. ایجاد توکن JWT
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes), // تنظیم مدت انقضا
                signingCredentials: credentials
            );

            // 5. تبدیل توکن به رشته و برگشت آن
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
