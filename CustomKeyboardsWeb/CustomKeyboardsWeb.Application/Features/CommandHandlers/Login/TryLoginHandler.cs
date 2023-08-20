﻿using AutoMapper;
using AutoMapper.Execution;
using CustomKeyboardsWeb.Application.Cummon.Abstractions;
using CustomKeyboardsWeb.Application.Features.Commands.Login;
using CustomKeyboardsWeb.Application.Features.Responses.Login;
using CustomKeyboardsWeb.Application.Features.Validations.Login;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;
using Member = CustomKeyboardsWeb.Domain.Primitives.Entities.Member;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Login
{
    public class TryLoginHandler : Handler<TryLoginCommand, TryLoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly IJwtProvider _jwtProvider;

        public TryLoginHandler(
            IMapper mapper,
            IMemberRepository memberRepository,
            IJwtProvider jwtProvider)
            : base(mapper)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _jwtProvider = jwtProvider;
        }

        public override async Task<TryLoginCommandResponse> Handle(TryLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var member = Member.Create(
                    Email.Create(request.LoginViewModel.Email),
                    Password.Create(request.LoginViewModel.Password),
                    Name.Create(""),
                    Address.Create(""),
                    Phone.Create(""),
                    "");

                var currentMember = await _memberRepository.FindByEmailAndPasswork(member);

                if (currentMember is null)
                    return new TryLoginCommandResponse(false, "Usuário não existente");

                string token = _jwtProvider.GenerateToken(currentMember);

                return new TryLoginCommandResponse(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(TryLoginCommand request)
        {
            var erros = new TryLoginCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
