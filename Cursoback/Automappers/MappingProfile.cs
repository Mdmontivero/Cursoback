using AutoMapper;
using Cursoback.DTOs;
using Cursoback.Model;

namespace Cursoback.Automappers

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //tiene todo los componentes para obrener el beer
            CreateMap<BeerInsertDto, Beer>();

            //cuando le falta un elemento del beerdto
            CreateMap<Beer, BeerDto>().ForMember(dto => dto.Id,
                m => m.MapFrom( b =>b.BeerId));

            CreateMap<BeerUpdateDto, Beer>();
        }
    }
}
