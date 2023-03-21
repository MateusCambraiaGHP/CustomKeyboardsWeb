using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Entity;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class KeyboardService : IKeyboardService
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public KeyboardService(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _keyboardRepository = keyboardRepository;
        }

        public async Task<KeyboardDto> Save(KeyboardDto model)
        {
            var keyboardMap = _mapper.Map<Keyboard>(model);
            await _keyboardRepository.Create(keyboardMap);
            return model;
        }

        public async Task<KeyboardDto> Edit(KeyboardDto model)
        {
            var keyboardMap = _mapper.Map<Keyboard>(model);
            await _keyboardRepository.Update(keyboardMap);
            return model;
        }

        public async Task<KeyboardDto> FindByIdAsync(int id)
        {
            var currentKeyboard = await _keyboardRepository.FindById(id) ?? new Keyboard();
            var keyboardMap = _mapper.Map<KeyboardDto>(currentKeyboard);
            return keyboardMap;
        }

        public async Task<List<KeyboardDto>> GetAll()
        {
            var listKeyboard = await _keyboardRepository.GetAll() ?? new List<Keyboard>();
            var listKeyboardMap = _mapper.Map<List<KeyboardDto>>(listKeyboard);
            return listKeyboardMap;
        }
    }
}