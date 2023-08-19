using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Application.Features.Validations.Members;
using CustomKeyboardsWeb.Application.Features.ViewModel.Members;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Members
{
    public class CreateMemberHandler : Handler<CreateMemberCommand, CreateMemberCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberHandler(
            IMemberRepository memberRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateMemberCommandResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var member = Member.Create(
                    Email.Create(request.MemberViewModel.Email),
                    Password.Create(request.MemberViewModel.Password),
                    Name.Create(request.MemberViewModel.Name),
                    Address.Create(request.MemberViewModel.Address),
                    Phone.Create(request.MemberViewModel.Phone),
                    request.MemberViewModel.Active);

                await _memberRepository.Create(member);
                await _unitOfWork.CommitChangesAsync();
                var memberViewModel = _mapper.Map<MemberViewModel>(member);

                return new CreateMemberCommandResponse(memberViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(CreateMemberCommand request)
        {
            var erros = new CreateMemberCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
