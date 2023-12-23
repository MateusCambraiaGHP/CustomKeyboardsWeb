using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.Validations.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Switchies
{
    public class UpdateSwitchHandler : Handler<UpdateSwitchCommand, UpdateSwitchCommandResponse>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateSwitchHandler(
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

        public override async Task<UpdateSwitchCommandResponse> Handle(UpdateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update switch", request.ValidationResult);

                var switchMap = _mapper.Map<Switch>(request.SwitchDto);
                switchMap.CreatedBy = "Administrator";
                await _switchRepository.Update(switchMap);
                await _unitOfWork.CommitChangesAsync();
                var switchViewModel = _mapper.Map<SwitchViewModel>(request);
                _cacheService.RemovePost(nameof(SwitchViewModel), nameof(SwitchViewModel));

                return new UpdateSwitchCommandResponse(switchViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateSwitchCommand request)
        {
            var erros = new UpdateSwitchCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
