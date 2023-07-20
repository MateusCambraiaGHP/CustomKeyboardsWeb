using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.Validations.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
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
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var keyboard = Keyboard.Create(
                    Name.Create(request.KeyboardViewModel.Name),
                    request.KeyboardViewModel.IdSwitch,
                    request.KeyboardViewModel.IdKey,
                    Price.Create(request.KeyboardViewModel.Price),
                    request.KeyboardViewModel.Active);
                await _keyboardRepository.Create(keyboard);
                await _unitOfWork.CommitChangesAsync();
                var keyboardViewModel = _mapper.Map<KeyboardViewModel>(keyboard);

                return new CreateKeyboardCommandResponse(keyboardViewModel);
            }
            catch (Exception)
            {
                var keyboardDtoMap = _mapper.Map<KeyboardViewModel>(request);
                return new CreateKeyboardCommandResponse(keyboardDtoMap);
            }
        }

        public override async Task<List<ValidationFailure>> Validate(CreateKeyboardCommand request)
        {
            var erros = await new CreateKeyboardCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
