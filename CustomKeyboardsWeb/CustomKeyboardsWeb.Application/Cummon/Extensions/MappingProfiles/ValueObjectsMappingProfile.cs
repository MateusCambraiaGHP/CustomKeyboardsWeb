using AutoMapper;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class ValueObjectsMappingProfile : Profile
    {
        public ValueObjectsMappingProfile()
        {
            CreateMap<Name, string>().ConvertUsing(n => n.Value);
            CreateMap<FantasyName, string>().ConvertUsing(fn => fn.Value);
            CreateMap<Cep, string>().ConvertUsing(c => c.Value);
            CreateMap<Address, string>().ConvertUsing(a => a.Value);
            CreateMap<Price, double>().ConvertUsing(p => p.Value);
            CreateMap<Phone, string>().ConvertUsing(p => p.Value);
            CreateMap<FederativeUnit, string>().ConvertUsing(fu => fu.Value);
            CreateMap<Color, string>().ConvertUsing(c => c.Value);
            CreateMap<Email, string>().ConvertUsing(c => c.Value);
            CreateMap<Password, string>().ConvertUsing(c => c.Value);
        }
    }
}
