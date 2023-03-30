using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Entity;

namespace MyHardwareWeb.Infrastructure.Services
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

        public async Task<KeyDto> Save(KeyDto model)
        {
            var keyMap = _mapper.Map<Key>(model);
            await _keyRepository.Create(keyMap);
            return model;
        }

        public async Task<KeyDto> Edit(KeyDto model)
        {
            var keyMap = _mapper.Map<Key>(model);
            await _keyRepository.Update(keyMap);
            return model;
        }

        public async Task<KeyDto> FindByIdAsync(int id)
        {
            var currentKey = await _keyRepository.FindById(id) ?? new Key();
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