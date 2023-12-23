using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.Validations.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Switchies
{
    public class CreateSwitchHandler : Handler<CreateSwitchCommand, CreateSwitchCommandResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public CreateSwitchHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<CreateSwitchCommandResponse> Handle(CreateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create switch", request.ValidationResult);

                var _switch = Switch.Create(
                    Name.Create(request.SwitchDto.Name),
                    Color.Create(request.SwitchDto.Color),
                    Price.Create(request.SwitchDto.Price),
                    request.SwitchDto.Active);

                await _switchRepository.Create(_switch);
                await _unitOfWork.CommitChangesAsync();
                var switchViewModel = _mapper.Map<SwitchViewModel>(_switch);
                _cacheService.RemovePost(nameof(SwitchViewModel), nameof(SwitchViewModel));

                return new CreateSwitchCommandResponse(switchViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateSwitchCommand request)
        {
            var erros = new CreateSwitchCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
