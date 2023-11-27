using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Members
{
    public class GetMemberListHandle : Handler<GetMemberListQuery, GetMemberListQueryResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberListHandle(
            IMemberRepository memberRepository,
            IMapper mapper)
            :base(mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public override async Task<GetMemberListQueryResponse> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listMember = await _memberRepository.GetAsync(null, null, null);
                var listMemberMap = _mapper.Map<List<MemberViewModel>>(listMember);
                return new GetMemberListQueryResponse(listMemberMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetMemberListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
