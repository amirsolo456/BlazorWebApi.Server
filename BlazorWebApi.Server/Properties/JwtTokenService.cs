using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


            //var claims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, username),
            //    new Claim(ClaimTypes.Role, usertype), // نقش کاربر
            //    new Claim("AccessLevel", accessLevel), // سطح دسترسی سفارشی
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            //// 2. ساخت SecurityKey از SecretKey
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            //// 3. تنظیم توکن
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //// 4. ایجاد توکن JWT
            //var token = new JwtSecurityToken(
            //    issuer: _jwtSettings.Issuer,
            //    audience: _jwtSettings.Audience,
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes), // تنظیم مدت انقضا
            //    signingCredentials: credentials
            //);

            //// 5. تبدیل توکن به رشته و برگشت آن
            //var handler = new JwtSecurityTokenHandler();
            //return handler.WriteToken(token);


            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aVeryLongAndSecureSecretKeyThatIsAtLeast32Bytes"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // تعریف اطلاعات توکن (Claims)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, usertype), // نقش کاربر
                new Claim("AccessLevel", accessLevel), // سطح دسترسی سفارشی
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            // ایجاد توکن
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            // تبدیل به فرمت JWS
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
