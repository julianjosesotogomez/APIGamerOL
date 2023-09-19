using APIGamerOL.Domain.Entities.CRUDEntities;
using APIGamerOL.DTO.CRUD;
using AutoMapper;

namespace APIGamerOL.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {

            CreateMap<VideoJuegosDTO, Videojuegos>().ReverseMap();
        }

    }
}
