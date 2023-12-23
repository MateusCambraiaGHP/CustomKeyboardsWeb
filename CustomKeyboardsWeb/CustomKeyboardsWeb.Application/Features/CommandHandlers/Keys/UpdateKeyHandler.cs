using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.Validations.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Keys
{
    public class UpdateKeyHandler : Handler<UpdateKeyCommand, UpdateKeyCommandResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateKeyHandler(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<UpdateKeyCommandResponse> Handle(UpdateKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update key", request.ValidationResult);

                var keyMap = _mapper.Map<Key>(request.KeyDto);
                keyMap.CreatedBy = "Administrator";
                await _keyRepository.Update(keyMap);
                await _unitOfWork.CommitChangesAsync();
                var keyViewModel = _mapper.Map<KeyViewModel>(keyMap);
                _cacheService.RemovePost(nameof(KeyViewModel), nameof(KeyViewModel));

                return new UpdateKeyCommandResponse(keyViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateKeyCommand request)
        {
            var erros = new UpdateKeyCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
