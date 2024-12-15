using Food_Recipe_Core.Models.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Helper.Security_Token
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(User input)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc#$vhHJVCBYHVSKDGHASVBCL");
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Email",input.Email),
                        new Claim("UserId",input.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(9),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }

        public static bool IsValidToken(string tokenString) //Decode
        {
            String toke = "Bearer " + tokenString;
            var jwtEncodedString = toke.Substring(7);
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            if (token.ValidTo > DateTime.UtcNow)
            {
                //Read Claims 
                int userId = int.Parse((token.Claims.First(c => c.Type == "UserId").Value.ToString()));
                //valid
                return true;
            }
            return false;
        }
    }
}
