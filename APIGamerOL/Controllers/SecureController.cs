using APIGamerOL.Application.Contracts;
using APIGamerOL.DTO.Register;
using APIGamerOL.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace APIGamerOL.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SecureController:ControllerBase
    {
        #region Fields

        private readonly ISecureApplication _registerApplication;

        #endregion

        #region Builder

        public SecureController(ISecureApplication registerApplication)
        {
            _registerApplication = registerApplication;
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route(nameof(SecureController.Register))]
        public async Task<ResponseEndPointDTO<bool>> Register(RegisterRequestDTO registerRequestDTO)
        {
            return await Task.Run(() =>
            {
                return _registerApplication.Register(registerRequestDTO);
            });
        }

        [HttpPost]
        [Route(nameof(SecureController.AuthenticationLogin))]
        public async Task<ResponseEndPointDTO<string>> AuthenticationLogin(AuthenticationLoginRequestDTO authenticationLoginRequestDTO)
        {
            return await Task.Run(() =>
            {
                return _registerApplication.AuthenticationLogin(authenticationLoginRequestDTO);
            });
        }

        #endregion

    }


}
