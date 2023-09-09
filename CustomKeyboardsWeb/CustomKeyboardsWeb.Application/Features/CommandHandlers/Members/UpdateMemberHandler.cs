using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.Validations.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Members
{
    public class UpdateMemberHandler : Handler<UpdateMemberCommand, UpdateMemberCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMemberHandler(
            IMemberRepository memberRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<UpdateMemberCommandResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var memberMap = _mapper.Map<Member>(request.MemberViewModel);
                memberMap.CreatedBy = "Administrator";
                await _memberRepository.Update(memberMap);
                await _unitOfWork.CommitChangesAsync();
                var memberViewModel = _mapper.Map<MemberViewModel>(memberMap);

                return new UpdateMemberCommandResponse(memberViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(UpdateMemberCommand request)
        {
            var erros = new UpdateMemberCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
