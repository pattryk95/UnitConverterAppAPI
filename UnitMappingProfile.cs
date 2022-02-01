using AutoMapper;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI
{
    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<Unit, UnitDto>().ReverseMap();
            CreateMap<CreateUnitDto, Unit>().ReverseMap();

            CreateMap<CreateConversionDto, Conversion>().ReverseMap();
            CreateMap<ConversionDto, Conversion>().ReverseMap();
        }
    }
}
