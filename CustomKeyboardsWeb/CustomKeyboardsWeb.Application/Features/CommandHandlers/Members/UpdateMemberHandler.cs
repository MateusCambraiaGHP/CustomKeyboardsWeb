using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.Validations.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Members;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Members
{
    public class UpdateMemberHandler : Handler<UpdateMemberCommand, UpdateMemberCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateMemberHandler(
            IMemberRepository memberRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<UpdateMemberCommandResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update member", request.ValidationResult);

                var memberMap = _mapper.Map<Member>(request.MemberDto);
                memberMap.CreatedBy = "Administrator";
                await _memberRepository.Update(memberMap);
                await _unitOfWork.CommitChangesAsync();
                var memberViewModel = _mapper.Map<MemberViewModel>(memberMap);
                _cacheService.RemovePost(nameof(MemberViewModel), nameof(MemberViewModel));

                return new UpdateMemberCommandResponse(memberViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateMemberCommand request)
        {
            var erros = new UpdateMemberCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
