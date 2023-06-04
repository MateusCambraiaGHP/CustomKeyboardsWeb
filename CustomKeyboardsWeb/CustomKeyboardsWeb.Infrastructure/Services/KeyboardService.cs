using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class KeyboardService : IKeyboardService
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKeyRepository _keyRepository;
        private readonly ISwitchRepository _switchRepository;

        public KeyboardService(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IKeyRepository keyRepository,
            ISwitchRepository switchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _keyRepository = keyRepository;
            _switchRepository = switchRepository;
            _keyboardRepository = keyboardRepository;
        }

        public async Task<KeyboardDto> Save(CreateKeyboardDto model)
        {
            try
            {
                var keyboard = Keyboard.Create(
                    Name.Create(model.Name),
                    model.IdSwitch,
                    model.IdKey,
                    Price.Create(model.Price),
                    model.Active);
                await _keyboardRepository.Create(keyboard);
                await _unitOfWork.CommitChangesAsync();
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(keyboard);
                return keyboardDtoMap;
            }
            catch (Exception)
            {
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(model);
                return keyboardDtoMap;
            }
        }

        public async Task<KeyboardDto> Edit(UpdateKeyboardDto model)
        {
            try
            {
                var keyboardMap = _mapper.Map<Keyboard>(model);
                keyboardMap.CreatedAt = DateTime.UtcNow;
                keyboardMap.CreatedBy = "Administrator";
                await _keyboardRepository.Update(keyboardMap);
                await _unitOfWork.CommitChangesAsync();
                var keyboardDtoMap = _mapper.Map<KeyboardDto>(model);
                return keyboardDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<KeyboardDto> FindByIdAsync(int id)
        {
            var currentKeyboard = await _keyboardRepository.FindById(id);
            var keyboardMap = _mapper.Map<KeyboardDto>(currentKeyboard);
            return keyboardMap;
        }

        public async Task<List<KeyboardDto>> GetAll()
        {
            var listKeyboard = await _keyboardRepository.GetAll() ?? new List<Keyboard>();
            var listKeyboardMap = _mapper.Map<List<KeyboardDto>>(listKeyboard);
            foreach (var keyboard in listKeyboardMap)
            {
                keyboard.Price += keyboard.Switch.Price.Value + keyboard.Key.Price.Value;
            }
            return listKeyboardMap;
        }
    }
}