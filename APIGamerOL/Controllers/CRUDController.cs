using APIGamerOL.Application.Contracts;
using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.DTO.CRUD;
using APIGamerOL.DTO.Response;
using Microsoft.AspNetCore.Mvc;


namespace APIGamerOL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CRUDController : ControllerBase
    {
        #region Fields
        private readonly ICRUDApplication _cRUDApplication;
        #endregion
        #region Builder
        public CRUDController(ICRUDApplication cRUDApplication)
        {
            _cRUDApplication = cRUDApplication;
        }
        #endregion
        #region Methods
        [HttpGet]
        [Route(nameof(CRUDController.GetVideoGame))]
        public async Task<ResponseEndPointDTO<List<VideoJuegosDTO>>> GetVideoGame()
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.GetVideoGame();
            });
        }

        [HttpPost]
        [Route(nameof(CRUDController.PagedVideoGame))]
        public async Task<ResponseEndPointDTO<List<VideoJuegosDTO>>> PagedVideoGame(RequestPagedVideoGameDTO requestPagedVideoGame)
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.PagedVideoGame(requestPagedVideoGame);
            });
        }

        [HttpGet]
        [Route(nameof(CRUDController.FindVideoGame))]
        public async Task<ResponseEndPointDTO<VideoJuegosDTO>> FindVideoGame(int idVideoGame)
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.FindVideoGame(idVideoGame);
            });
        }

        [HttpPost]
        [Route(nameof(CRUDController.CreateVideoGame))]
        public async Task<ResponseEndPointDTO<bool>> CreateVideoGame(RequestCreateVideoGameDTO requestCreateVideoGameDTO)
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.CreateVideoGame(requestCreateVideoGameDTO);
            });
        }

        [HttpPut("{id}")]
        //[Route(nameof(CRUDController.UpdateVideoGame))]
        public async Task<ResponseEndPointDTO<bool>> UpdateVideoGame(int id, RequestUpdateVideoGameDTO requestUpdateVideoGameDTO)
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.UpdateVideoGame(id, requestUpdateVideoGameDTO);
            });
        }

        [HttpDelete]
        [Route(nameof(CRUDController.DeleteVideoGame))]
        public async Task<ResponseEndPointDTO<bool>> DeleteVideoGame(int id)
        {
            return await Task.Run(() =>
            {
                return _cRUDApplication.DeleteVideoGame(id);
            });
        }
        #endregion
    }
}
