using AutoMapper;
using VerificaDespesas.DTOs;
using VerificaDespesas.Models;

namespace VerificaDespesas.Mapppings;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<Despesa, DespesaDto>();
    }
}