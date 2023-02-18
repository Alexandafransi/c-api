using AutoMapper;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Helper;
// mapping class for map Modal and Dto that u specify modal field you want to be shown
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();

    }
}