using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey;
using CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class KeyService : IKeyService
    {
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;

        public KeyService(
            IKeyRepository keyRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _keyRepository = keyRepository;
        }

        public async Task<KeyDto> Save(CreateKeyDto model)
        {
            var key = Key.Create(
                Name.Create(model.Name),
                Price.Create(model.Price),
                model.Active);

            await _keyRepository.Create(key);
            var keyDto = _mapper.Map<KeyDto>(key);
            return keyDto;
        }

        public async Task<KeyDto> Edit(UpdateKeyDto model)
        {
            var keyMap = _mapper.Map<Key>(model);
            keyMap.CreatedAt = DateTime.UtcNow;
            keyMap.CreatedBy = "Administrator";
            await _keyRepository.Update(keyMap);
            var keyDtoMap = _mapper.Map<KeyDto>(model);
            return keyDtoMap;
        }

        public async Task<KeyDto> FindByIdAsync(int id)
        {
            var currentKey = await _keyRepository.FindById(id);
            var keyMap = _mapper.Map<KeyDto>(currentKey);
            return keyMap;
        }

        public async Task<List<KeyDto>> GetAll()
        {
            var listKey = await _keyRepository.GetAll() ?? new List<Key>();
            var listKeyMap = _mapper.Map<List<KeyDto>>(listKey);
            return listKeyMap;
        }
    }
}