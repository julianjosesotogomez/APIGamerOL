using APIGamerOL.Application.Contracts;
using APIGamerOL.Domain.Entities.SecureEntities;
using APIGamerOL.Domain.Services.SecureDomainServices.Contracts;
using APIGamerOL.DTO.Register;
using APIGamerOL.DTO.Response;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIGamerOL.Application
{
    public class SecureApplication:ISecureApplication
    {
        #region Fields
        private readonly ISecureDomainServices _secureDomainServices;
        private readonly string _secretKey;

        #endregion

        #region Build
        public SecureApplication(ISecureDomainServices secureDomainServices, IConfiguration configuration) 
        {
            _secureDomainServices = secureDomainServices;
            _secretKey = configuration.GetSection("settings").GetSection("secretKey").ToString();
        }
        #endregion

        #region Methods
        public ResponseEndPointDTO<bool> Register(RegisterRequestDTO registerRequestDTO)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                if (string.IsNullOrWhiteSpace(registerRequestDTO.UserName))
                {
                    response.ResponseMessage("Campo UserName obligatorio", false);
                    return response;
                }
                else if (string.IsNullOrWhiteSpace(registerRequestDTO.Password))
                {
                    response.ResponseMessage("Campo Password obligatorio", false);
                    return response;
                }
                else if (string.IsNullOrWhiteSpace(registerRequestDTO.Email))
                {
                    response.ResponseMessage("Campo Email obligatorio", false);
                    return response;
                }
                else
                {
                    Usuario usuario = new Usuario();
                    usuario.NombreUsuario = registerRequestDTO.UserName;
                    usuario.CorreoElectronico = registerRequestDTO.Email;
                    usuario.Contrasena=registerRequestDTO.Password;
                    usuario.FechaRegistro = DateTime.Now;

                    _secureDomainServices.Insert(usuario);
                }
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<string> AuthenticationLogin(AuthenticationLoginRequestDTO authenticationLoginRequestDTO)
        {
            ResponseEndPointDTO<string> response = new ResponseEndPointDTO<string>();
            try
            {
                var resultUser = _secureDomainServices.Find(authenticationLoginRequestDTO.Email, authenticationLoginRequestDTO.Password);
                if(resultUser != null)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
                    var claims = new ClaimsIdentity();

                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, authenticationLoginRequestDTO.Email));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string createToken = tokenHandler.WriteToken(tokenConfig);

                    response.Result= createToken;
                }
                else
                {
                    response.ResponseMessage("No se encuentra usuario registrado en la BD", false);
                    return response;
                }
                
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }

            return response;
        }

        #endregion

        #region Private Methods


        #endregion

    }
}
