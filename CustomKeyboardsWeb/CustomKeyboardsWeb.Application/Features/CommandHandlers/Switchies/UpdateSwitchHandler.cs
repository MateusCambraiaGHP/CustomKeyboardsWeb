using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.Validations.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Switchies
{
    public class UpdateSwitchHandler : Handler<UpdateSwitchCommand, UpdateSwitchCommandResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSwitchHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<UpdateSwitchCommandResponse> Handle(UpdateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var switchMap = _mapper.Map<Switch>(request.SwitchViewModel);
                switchMap.CreatedAt = DateTime.UtcNow;
                switchMap.CreatedBy = "Administrator";
                await _switchRepository.Update(switchMap);
                await _unitOfWork.CommitChangesAsync();
                var switchViewModel = _mapper.Map<SwitchViewModel>(request);

                return new UpdateSwitchCommandResponse(switchViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(UpdateSwitchCommand request)
        {
            var erros = await new UpdateSwitchCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
