using Microsoft.IdentityModel.Tokens;
using MujeebOnline.Entities;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MujeebOnline.Utility
{
    public static class JWTUtiltiy
    {
        public static string GenerateJSONWebToken(UserSession request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.GetValue("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim("UserID", request.UserID.ToString()),
        new Claim("UserName", request.UserName),
        new Claim("Mydetails1", request.Mydetails1),
        new Claim("Mydetails2", request.Mydetails2),
        new Claim("UserRequestID", request.UserRequestID.ToString()),
        new Claim("DateOfTokenGenerated", DateTime.Now.ToString())
    };

            var token = new JwtSecurityToken(ConfigurationManager.GetValue("Jwt:Issuer"),
                ConfigurationManager.GetValue("Jwt:Audience"),
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static void ValidateJSONWebToken(string tokenInput, out bool statusJWT, out UserSession userdetails)
        {
            userdetails = new();
            statusJWT = false;
            if (string.IsNullOrEmpty(tokenInput)) { return; }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.GetValue("Jwt:Key")));
                tokenHandler.ValidateToken(tokenInput, new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = ConfigurationManager.GetValue("Jwt:Issuer"),
                    ValidAudience = ConfigurationManager.GetValue("Jwt:Audience")
                }, out SecurityToken validateToken);


                var jwtToken = (JwtSecurityToken)validateToken;
                userdetails.UserID = int.Parse(jwtToken.Claims.FirstOrDefault(_ => _.Type == "UserID").Value);
                userdetails.UserName = jwtToken.Claims.FirstOrDefault(_ => _.Type == "UserName").Value;
                userdetails.Mydetails1 = jwtToken.Claims.FirstOrDefault(_ => _.Type == "Mydetails1").Value;
                userdetails.Mydetails2 = jwtToken.Claims.FirstOrDefault(_ => _.Type == "Mydetails2").Value;
                //Guid value = (Guid)jwtToken.Claims.FirstOrDefault(_ => _.Type == "UserRequestID").Value;
                //userdetails.UserRequestID = value;
            }
            catch (Exception ex)
            {
            }

        }
    }
}
