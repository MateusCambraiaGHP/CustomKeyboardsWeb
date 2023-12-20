using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.Validations.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
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
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update keyboard", request.ValidationResult);

                var keyboardMap = _mapper.Map<Keyboard>(request.KeyboardDto);
                keyboardMap.CreatedBy = "Administrator";
                await _keyboardRepository.Update(keyboardMap);
                await _unitOfWork.CommitChangesAsync();
                var keyboardViewModel = _mapper.Map<KeyboardViewModel>(keyboardMap);

                return new UpdateKeyboardCommandResponse(keyboardViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateKeyboardCommand request)
        {
            var erros = new UpdateKeyboardCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
