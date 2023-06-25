using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.Validations.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Keys
{
    public class CreateKeyHandler : Handler<CreateKeyCommand, CreateKeyCommandResponse>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateKeyHandler(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateKeyCommandResponse> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var key = Key.Create(
                    Name.Create(request.KeyViewModel.Name),
                    Price.Create(request.KeyViewModel.Price),
                    request.KeyViewModel.Active);

                await _keyRepository.Create(key);
                await _unitOfWork.CommitChangesAsync();
                var keyViewModel = _mapper.Map<KeyViewModel>(key);

                return new CreateKeyCommandResponse(keyViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(CreateKeyCommand request)
        {
            var erros = await new CreateKeyCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
