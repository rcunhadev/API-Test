using Desafio.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.API.Authorization
{
    public class Token
    {
        public AuthenticateUser GenerateToken(LoginDto user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                new Claim("User", user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var keyword = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("uoiuiuiuiyu7676lk434098976-3jkgfdroqw8675764s"));
            var credencials = new SigningCredentials(keyword, SecurityAlgorithms.HmacSha256);


            var expiration = DateTime.Now.AddMinutes(5);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: credencials);


            return new AuthenticateUser()
            {
                Name = user.Login,
                IsAuth = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
