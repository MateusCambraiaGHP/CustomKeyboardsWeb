using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Members
{
    public class GetMemberByIdHandle : Handler<GetMemberByIdQuery, GetMemberByIdQueryResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberByIdHandle(
            IMemberRepository memberRepository,
            IMapper mapper)
            : base(mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public override async Task<GetMemberByIdQueryResponse> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentMember = await _memberRepository.GetAsync(mb => mb.Id == request.IdMember, null, null);
                var memberMap = _mapper.Map<MemberViewModel>(currentMember);
                return new GetMemberByIdQueryResponse(memberMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetMemberByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
