using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.CreateKey
{
    public class CreateKeyHandler : IRequestHandler<CreateKeyCommand, KeyDto>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateKeyHandler(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<KeyDto> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var key = Key.Create(
                    Name.Create(request.createKeyDto.Name),
                    Price.Create(request.createKeyDto.Price),
                    request.createKeyDto.Active);

                await _keyRepository.Create(key);
                await _unitOfWork.CommitChangesAsync();
                var keyDto = _mapper.Map<KeyDto>(key);
                return keyDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
