using AutoMapper;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pokemon, PokemonDto>();
    }
}