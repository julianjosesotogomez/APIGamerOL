using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.DTO.CRUD;
using APIGamerOL.DTO.Response;

namespace APIGamerOL.Application.Contracts
{
    public interface ICRUDApplication
    {
        public ResponseEndPointDTO<List<VideoJuegosDTO>> GetVideoGame();
        public ResponseEndPointDTO<List<VideoJuegosDTO>> PagedVideoGame(RequestPagedVideoGameDTO requestPagedVideoGame);
        public ResponseEndPointDTO<VideoJuegosDTO> FindVideoGame(int idVideoGame);
        public ResponseEndPointDTO<bool> CreateVideoGame(RequestCreateVideoGameDTO requestCreateVideoGameDTO);
        public ResponseEndPointDTO<bool> UpdateVideoGame(int id, RequestUpdateVideoGameDTO requestUpdateVideoGameDTO);
        public ResponseEndPointDTO<bool> DeleteVideoGame(int id);
    }
}
