using AutoMapper;
using VerificaDespesas.DTOs;
using VerificaDespesas.Models;

namespace VerificaDespesas.Mapppings;

public class DeputadoProfile : Profile
{
    public DeputadoProfile()
    {
        CreateMap<Deputado, DeputadoDto>().ReverseMap();
    }
}
