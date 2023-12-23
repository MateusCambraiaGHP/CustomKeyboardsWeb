using AutoMapper;
using CustomKeyboardsWeb.Application.Dtos.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Domain.Primitives.Entities;

namespace CustomKeyboardsWeb.Application.Cummon.Extensions.MappingProfiles
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<Member, MemberViewModel>().ReverseMap();
            CreateMap<Member, UpdateMemberDto>().ReverseMap();
        }
    }
}
