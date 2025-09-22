using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace EShopper.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                claims.Add(new Claim("UserName", model.UserName));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expaireTime = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expaireTime,
                signingCredentials: creds
            );

            JwtSecurityTokenHandler token = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(token.WriteToken(jwtSecurityToken), expaireTime);

        }
    }
}
