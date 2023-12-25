using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.Validations.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Members;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Members
{
    public class CreateMemberHandler : Handler<CreateMemberCommand, CreateMemberCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public CreateMemberHandler(
            IMemberRepository memberRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<CreateMemberCommandResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create member", request.ValidationResult);

                var member = Member.Create(
                    Email.Create(request.MemberDto.Email),
                    Password.Create(request.MemberDto.Password),
                    Name.Create(request.MemberDto.Name),
                    Address.Create(request.MemberDto.Address),
                    Phone.Create(request.MemberDto.Phone),
                    request.MemberDto.Active);

                await _memberRepository.Create(member);
                await _unitOfWork.CommitChangesAsync();
                var memberViewModel = _mapper.Map<MemberViewModel>(member);
                _cacheService.RemovePost(nameof(MemberViewModel), nameof(MemberViewModel));

                return new CreateMemberCommandResponse(memberViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateMemberCommand request)
        {
            var erros = new CreateMemberCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
