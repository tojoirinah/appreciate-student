using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Appreciation.Manager.Utils
{
    public class JwtTokenHelper
    {
        public static string CreateToken(ClaimsIdentity claimsIdentity, int expiresMinute, string secretKey)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime notBefore = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = issuedAt.AddMinutes(expiresMinute);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = expires,
                IssuedAt = issuedAt,
                NotBefore = notBefore,
                SigningCredentials = signingCredentials
            };

            //create the jwt
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public IEnumerable<Claim> GetTokenClaims(string token, string secretKey)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("token is null or empty");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters(secretKey);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                SecurityToken validatedToken;
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IsTokenValid(string token, string secretKey)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("token is null or empty");

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters(secretKey);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                SecurityToken validatedToken = null;
                jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                return validatedToken != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TokenValidationParameters GetTokenValidationParameters(string secretKey)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                 ValidAudience = Settings.ValidAudience,
                ValidIssuer = Settings.ValidIssuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                LifetimeValidator = LifetimeValidator,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey))
            };

            return validationParameters;
        }

        static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
