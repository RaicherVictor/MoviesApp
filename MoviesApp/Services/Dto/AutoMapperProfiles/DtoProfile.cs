using AutoMapper;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class DtoProfile:Profile
    {
        public DtoProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}