using AutoMapper;
using DevSu.Core.Models;
using DevSu.Services.Dto;

namespace DevSu.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cuenta, CuentaDto>().ReverseMap();
            CreateMap<Movimiento, MovimientoDto>().ReverseMap();

            CreateMap<Movimiento, MovimientoCreateDto>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDto>().ReverseMap();
            CreateMap<Cuenta, CuentaCreateDto>().ReverseMap();
        }
    }
}
