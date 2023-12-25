using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.Validations.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Keys
{
    public class CreateKeyHandler : Handler<CreateKeyCommand, CreateKeyCommandResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public CreateKeyHandler(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _keyRepository = keyRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<CreateKeyCommandResponse> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create key", request.ValidationResult);

                var key = Key.Create(
                    Name.Create(request.KeyDto.Name),
                    Price.Create(request.KeyDto.Price),
                    request.KeyDto.Active);

                await _keyRepository.Create(key);
                await _unitOfWork.CommitChangesAsync();
                var keyViewModel = _mapper.Map<KeyViewModel>(key);
                _cacheService.RemovePost(nameof(KeyViewModel), nameof(KeyViewModel));

                return new CreateKeyCommandResponse(keyViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateKeyCommand request)
        {
            var erros = new CreateKeyCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
