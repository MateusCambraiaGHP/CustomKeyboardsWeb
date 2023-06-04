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
        private readonly IUnitOfWork _unitOfWork;

        public KeyService(
            IKeyRepository keyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _keyRepository = keyRepository;
        }

        public async Task<KeyDto> Save(CreateKeyDto model)
        {
            try
            {
                var key = Key.Create(
             Name.Create(model.Name),
             Price.Create(model.Price),
             model.Active);

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

        public async Task<KeyDto> Edit(UpdateKeyDto model)
        {
            try
            {
                var keyMap = _mapper.Map<Key>(model);
                keyMap.CreatedAt = DateTime.UtcNow;
                keyMap.CreatedBy = "Administrator";
                await _keyRepository.Update(keyMap);
                await _unitOfWork.CommitChangesAsync();
                var keyDtoMap = _mapper.Map<KeyDto>(model);
                return keyDtoMap;
            }
            catch (Exception)
            {

                throw;
            }
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