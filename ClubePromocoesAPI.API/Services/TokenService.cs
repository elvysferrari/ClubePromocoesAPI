using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClubePromocoesAPI.API.Config;
using ClubePromocoesAPI.Reads.UsuarioModule.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace ClubePromocoesAPI.API.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioAutenticadoDTO usuario)
        {
            /*
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.idUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.idUsuario.ToString()),
                    new Claim(ClaimTypes.Name, usuario.login),                                        
                    new Claim(ClaimTypes.Email, usuario.email),
                    new Claim(ClaimTypes.Role, "TI")
                }),
                Expires = DateTime.UtcNow.AddHours(TokenConfig.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);*/

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,  usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, "USER"),
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddHours(4);

            var token = new JwtSecurityToken(
                "",
                "",
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
