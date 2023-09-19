using APIGamerOL.Application.Contracts;
using APIGamerOL.DTO.Register;
using APIGamerOL.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace APIGamerOL.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SecureController:ControllerBase
    {
        #region Fields

        private readonly ISecureApplication _secureApplication;

        #endregion

        #region Builder

        public SecureController(ISecureApplication secureApplication)
        {
            _secureApplication = secureApplication;
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route(nameof(SecureController.Register))]
        public async Task<ResponseEndPointDTO<bool>> Register(RegisterRequestDTO registerRequestDTO)
        {
            return await Task.Run(() =>
            {
                return _secureApplication.Register(registerRequestDTO);
            });
        }

        [HttpPost]
        [Route(nameof(SecureController.AuthenticationLogin))]
        public async Task<ResponseEndPointDTO<string>> AuthenticationLogin(AuthenticationLoginRequestDTO authenticationLoginRequestDTO)
        {
            return await Task.Run(() =>
            {
                return _secureApplication.AuthenticationLogin(authenticationLoginRequestDTO);
            });
        }

        #endregion

    }


}
