using GatewayApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIGateway.Services
{
    public class ApiTokenService    
    {

        
        public AuthToken GenerateToken(AuthUser user)        
        {

            
            var key = new SymmetricSecurityKey
               (Encoding.UTF8.GetBytes("my_api_secret"));
            var credentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);
        
            var claims = new []            
            {
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()) , 
            new Claim(JwtRegisteredClaimNames.Name, user.Username.ToString()),
            new Claim("Role", "Admin")
                      
        };
        
        var token = new JwtSecurityToken(
                audience: "https://localhost:5003",
                issuer: "https://localhost:5003",
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials);
       
        var authToken = new AuthToken
        {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        ExpirationDate = expirationDate
        };
        
        return authToken;        
    }    
 }
}