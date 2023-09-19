using APIGamerOL.Application.Contracts;
using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.Domain.Services.CRUDDomainServices.Contracts;
using APIGamerOL.DTO.CRUD;
using APIGamerOL.DTO.Response;
using AutoMapper;

namespace APIGamerOL.Application
{
    public class CRUDApplication:ICRUDApplication
    {
        #region Fields
        private readonly ICRUDDomainServices _cRUDDomainServices;
        private readonly IMapper _mapper;
        #endregion
        #region Builder
        public CRUDApplication(IMapper mapper,ICRUDDomainServices cRUDDomainServices)
        {
            _mapper = mapper;
            _cRUDDomainServices = cRUDDomainServices;
        }
        #endregion
        #region Methods
        public ResponseEndPointDTO<List<VideoJuegosDTO>> GetVideoGame()
        {
            ResponseEndPointDTO<List<VideoJuegosDTO>> response = new ResponseEndPointDTO<List<VideoJuegosDTO>>();
            try
            {
                var listData = _cRUDDomainServices.List();
                var videoGameList = _mapper.Map<List<VideoJuegosDTO>>(listData);

                response.Result = videoGameList;
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<List<VideoJuegosDTO>> PagedVideoGame(RequestPagedVideoGameDTO requestPagedVideoGame)
        {
            ResponseEndPointDTO<List<VideoJuegosDTO>> response = new ResponseEndPointDTO<List<VideoJuegosDTO>>();
            try
            {
                var listPaged = _cRUDDomainServices.PagedList(requestPagedVideoGame);
                var pagedvideoGameList = _mapper.Map<List<VideoJuegosDTO>>(listPaged);

                response.Result = pagedvideoGameList.OrderBy(x=>x.Id).Take(5).ToList();
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<VideoJuegosDTO> FindVideoGame(int idVideoGame)
        {
            ResponseEndPointDTO<VideoJuegosDTO> response = new ResponseEndPointDTO<VideoJuegosDTO>();
            try
            {
                var videoGame = _cRUDDomainServices.FindVideoGame(idVideoGame);
                if(videoGame == null)
                {
                    response.ResponseMessage($"No se encuentra video Juego con el id {idVideoGame}", false);
                    return response;
                }
                var dataVideoGame = _mapper.Map<VideoJuegosDTO>(videoGame);

                response.Result = dataVideoGame;
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> CreateVideoGame(RequestCreateVideoGameDTO requestCreateVideoGameDTO)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {

                VideoJuegosDTO createNew = new VideoJuegosDTO();
                createNew.Nombre = requestCreateVideoGameDTO.Name;
                createNew.Compañia = requestCreateVideoGameDTO.Company;
                createNew.AñoLanzamiento = requestCreateVideoGameDTO.YearOfLaunch;
                createNew.Precio = requestCreateVideoGameDTO.Price;
                createNew.Puntaje = requestCreateVideoGameDTO.Score;
                createNew.FechaActualizacion = DateTime.Now;
                createNew.Usuario = requestCreateVideoGameDTO.User;


                var newvideoGame= _mapper.Map<Videojuegos>(createNew);

                _cRUDDomainServices.CreateVideoGame(newvideoGame);

            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> UpdateVideoGame(int id, RequestUpdateVideoGameDTO requestUpdateVideoGameDTO)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var videoGame = _cRUDDomainServices.FindVideoGame(id);
                if (videoGame == null)
                {
                    response.ResponseMessage($"No se encuentra video Juego con el id {id}", false);
                    return response;
                }

                int num = 0;
                decimal deInt = num;

                Videojuegos createNew = new Videojuegos();
                createNew.Id = id;
                createNew.Nombre = requestUpdateVideoGameDTO.Name is null?videoGame.Nombre: requestUpdateVideoGameDTO.Name;
                createNew.Compañia = requestUpdateVideoGameDTO.Company is null ? videoGame.Nombre : requestUpdateVideoGameDTO.Name; ;
                createNew.AñoLanzamiento = requestUpdateVideoGameDTO.YearOfLaunch is 0 ? videoGame.AñoLanzamiento : requestUpdateVideoGameDTO.YearOfLaunch; ;
                createNew.Precio =  requestUpdateVideoGameDTO.Price is 0 ? videoGame.Precio : requestUpdateVideoGameDTO.Price; ;
                createNew.Puntaje = requestUpdateVideoGameDTO.Score is 0 ? videoGame.Puntaje : requestUpdateVideoGameDTO.Score; ;
                createNew.FechaActualizacion = DateTime.Now;
                createNew.Usuario = requestUpdateVideoGameDTO.User is null ?videoGame.Usuario:requestUpdateVideoGameDTO.User;


                var newvideoGame = _mapper.Map<Videojuegos>(createNew);

                _cRUDDomainServices.UpdateVideoGame(id,newvideoGame);

            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> DeleteVideoGame(int id)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var videoGame = _cRUDDomainServices.FindVideoGame(id);
                if (videoGame == null)
                {
                    response.ResponseMessage($"No se encuentra video Juego con el id {id}", false);
                    return response;
                }

                _cRUDDomainServices.DeleteVideoGame(id);

            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }
        #endregion
    }
}
