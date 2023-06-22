using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys.UpdateKey
{
    public class UpdateKeyHandler : IRequestHandler<UpdateKeyCommand, KeyDto>
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateKeyHandler(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _keyRepository = keyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<KeyDto> Handle(UpdateKeyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var keyMap = _mapper.Map<Key>(request.UpdateKeyDto);
                keyMap.CreatedAt = DateTime.UtcNow;
                keyMap.CreatedBy = "Administrator";
                await _keyRepository.Update(keyMap);
                await _unitOfWork.CommitChangesAsync();
                var keyDtoMap = _mapper.Map<KeyDto>(keyMap);
                return keyDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
