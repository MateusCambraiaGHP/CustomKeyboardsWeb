using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Abstractions;
using CustomKeyboardsWeb.Application.Features.Commands.Login;
using CustomKeyboardsWeb.Application.Features.Responses.Login;
using CustomKeyboardsWeb.Application.Features.Validations.Login;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Login
{
    public class TryLoginHandler : Handler<TryLoginCommand, TryLoginCommandResponse>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;

        public TryLoginHandler(
            IMapper mapper,
            IMemberRepository memberRepository,
            IJwtProvider jwtProvider,
            IUnitOfWork unitOfWork)
            : base(mapper)
        {
            _memberRepository = memberRepository;
            _jwtProvider = jwtProvider;
            _unitOfWork = unitOfWork;
        }

        public override async Task<TryLoginCommandResponse> Handle(TryLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("cannot possible generate token, invalid user", request.ValidationResult);

                var currentMember = await _memberRepository.GetAsync(m => m.Email.Value == request.LoginViewModel.Email && m.Password.Value == request.LoginViewModel.Password, null, null);
                if (currentMember.FirstOrDefault() is null)
                    return new TryLoginCommandResponse(false, "cannot possible generate token, the user dont exists");

                string token = _jwtProvider.GenerateToken(currentMember.FirstOrDefault());
                currentMember.FirstOrDefault().SetToken(token);
                await _memberRepository.Update(currentMember.FirstOrDefault());
                await _unitOfWork.CommitChangesAsync();

                return new TryLoginCommandResponse(token);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(TryLoginCommand request)
        {
            var erros = new TryLoginCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
