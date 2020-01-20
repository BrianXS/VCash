using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.Utils
{
    public static class TokenUtility
    {
        public static TokenValidationParameters TokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "VCash",
                
                ValidateAudience = true,
                ValidAudience = "localhost",
                
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.General.TokenSecret))
            };
        }

        public static string GenerateToken(List<Claim> claims)
        {
            var parameters = TokenValidationParameters();
            var token = new JwtSecurityToken(issuer: parameters.ValidIssuer, 
                audience: parameters.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials(parameters.IssuerSigningKey, 
                    SecurityAlgorithms.HmacSha256));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GenerateRefreshToken()
        {
            var refreshToken = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(refreshToken);
            }
            return Convert.ToBase64String(refreshToken);
        }

        public static ClaimsPrincipal GetClaimsPrincipal(string oldToken)
        {
            var parameters = TokenValidationParameters();
            parameters.ValidateLifetime = false;

            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(oldToken, parameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                throw new SecurityTokenException();
            
            return principal;
        }
    }
}