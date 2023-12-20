using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.Validations.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Keyboards
{
    public class CreateKeyboardHandler : Handler<CreateKeyboardCommand, CreateKeyboardCommandResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateKeyboardHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateKeyboardCommandResponse> Handle(CreateKeyboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create keyboard", request.ValidationResult);

                var keyboard = Keyboard.Create(
                    Name.Create(request.KeyboardDto.Name),
                    request.KeyboardDto.IdSwitch,
                    request.KeyboardDto.IdKey,
                    Price.Create(request.KeyboardDto.Price),
                    request.KeyboardDto.Active);

                if(!keyboard.ValidationResult.IsValid)
                    return ResponseOnFailValidation("", keyboard.ValidationResult.Errors);

                await _keyboardRepository.Create(keyboard);
                await _unitOfWork.CommitChangesAsync();
                var keyboardViewModel = _mapper.Map<KeyboardViewModel>(keyboard);

                return new CreateKeyboardCommandResponse(keyboardViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateKeyboardCommand request)
        {
            var erros = new CreateKeyboardCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
