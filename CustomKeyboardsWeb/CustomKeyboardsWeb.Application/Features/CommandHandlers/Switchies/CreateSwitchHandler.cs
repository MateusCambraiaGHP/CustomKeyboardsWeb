using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.Validations.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Switchies
{
    public class CreateSwitchHandler : Handler<CreateSwitchCommand, CreateSwitchCommandResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSwitchHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateSwitchCommandResponse> Handle(CreateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var _switch = Switch.Create(
                    Name.Create(request.SwitchViewModel.Name),
                    Color.Create(request.SwitchViewModel.Color),
                    Price.Create(request.SwitchViewModel.Price),
                    request.SwitchViewModel.Active);

                await _switchRepository.Create(_switch);
                await _unitOfWork.CommitChangesAsync();
                var switchViewModel= _mapper.Map<SwitchViewModel>(_switch);

                return new CreateSwitchCommandResponse(switchViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(CreateSwitchCommand request)
        {
            var erros = await new CreateSwitchCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
