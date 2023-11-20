using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PayCore.API.Models.Auth
{
    public class PayCoreTokenHandler
    {
        public Token CreateAccessToken(string email)
        {
            var claimsData = new[]
            {
                new Claim(ClaimTypes.Email, email)
                //new Claim("email", email)

            };

            //return edecegim token modelim
            var token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("loremipsimloremipsimloremipsimloremipsimloremipsim"));

            //token icin sifreleme algoritmasini belirtiyorum
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpireDate = DateTime.Now.AddMinutes(10);

            //olusturdugum token ozellikleri
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:"cagatay@mail.com",
                audience:"cagatay2@mail.com",
                signingCredentials: signingCredentials,
                expires: token.ExpireDate,
                claims: claimsData
               );

            //token create ediyorum
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create
                ())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
