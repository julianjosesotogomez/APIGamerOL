using APIGamerOL.DTO.Register;
using APIGamerOL.DTO.Response;

namespace APIGamerOL.Application.Contracts
{
    public interface ISecureApplication
    {
        public ResponseEndPointDTO<bool> Register(RegisterRequestDTO registerRequestDTO);
        public ResponseEndPointDTO<string> AuthenticationLogin(AuthenticationLoginRequestDTO authenticationLoginRequestDTO);
    }
}
