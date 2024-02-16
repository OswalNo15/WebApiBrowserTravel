using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProyectoCrud.Models.Custom;
using Microsoft.Extensions.Configuration;
using ProyectoCrud.DAL.BD_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;


namespace ProyectoCrud.DAL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly BdMilesCarRentalContext _contetxt;
        private readonly IConfiguration _configuration;
        public AuthorizationService(BdMilesCarRentalContext context, IConfiguration configuration)
        {
            _contetxt = context;
            _configuration = configuration;
        }

        private string GenerateToken(string idUSer) {
            var key = _configuration.GetValue<string>("JWTSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            #region Informacion del id del usuario con claims
            claims.AddClaim(new Claim(
              ClaimTypes.NameIdentifier, idUSer
              ));

            #endregion

            #region Credeciales para el token
            var CredentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );
            #endregion

            #region Detalle del token
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials= CredentialsToken
            };
            #endregion

            #region creacion de los controladores del JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfiguration = tokenHandler.CreateToken(TokenDescriptor);
            string tokenCreate = tokenHandler.WriteToken(tokenConfiguration);
            #endregion

            return tokenCreate;
        }

        private string GetEncrypterPaswoordHash256(string Password) { 
            var Bytes= Encoding.UTF8.GetBytes(Password);
            var hash = SHA256.HashData(Bytes);
            var hasComplete = string.Format("0x{0}", Convert.ToHexString(hash));
            return hasComplete;
        }

        public async Task<AuthorizationResponse> ReturnToken(AuthorizationRequest Authorization)
        {
            string paswoordHash = GetEncrypterPaswoordHash256(Authorization.Password);
            var userFound = await _contetxt.Users.FirstOrDefaultAsync(x =>
            x.Name.ToUpper().Equals(Authorization.NameUser.ToUpper()) && x.Passwordhash.Equals(paswoordHash));

            if (userFound == null) {
                return await Task.FromResult<AuthorizationResponse>(null);
            }

            string tokenCreate = GenerateToken(userFound.IdUser.ToString());

            return new AuthorizationResponse() { Token = tokenCreate, result = true, message = "sucessfully" };
        }
    }
}
