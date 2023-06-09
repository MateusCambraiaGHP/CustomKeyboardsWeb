﻿using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.Validations.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Keyboards
{
    public class UpdateKeyboardHandler : Handler<UpdateKeyboardCommand, UpdateKeyboardCommandResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateKeyboardHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<UpdateKeyboardCommandResponse> Handle(UpdateKeyboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var keyboardMap = _mapper.Map<Keyboard>(request.KeyboardViewModel);
                keyboardMap.CreatedAt = DateTime.UtcNow;
                keyboardMap.CreatedBy = "Administrator";
                await _keyboardRepository.Update(keyboardMap);
                await _unitOfWork.CommitChangesAsync();
                var keyboardViewModel = _mapper.Map<KeyboardViewModel>(keyboardMap);

                return new UpdateKeyboardCommandResponse(keyboardViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(UpdateKeyboardCommand request)
        {
            var erros = await new UpdateKeyboardCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
