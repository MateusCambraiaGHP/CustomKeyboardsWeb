using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class SwitchService : ISwitchService
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public SwitchService(
            ISwitchRepository switchRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _switchRepository = switchRepository;
        }

        public async Task<SwitchDto> Save(CreateSwitchDto model)
        {
            var _switch = Switch.Create(
                Name.Create(model.Name),
                Color.Create(model.Color),
                Price.Create(model.Price),
                model.Active);

            await _switchRepository.Create(_switch);
            var switchDto = _mapper.Map<SwitchDto>(_switch);
            return switchDto;
        }

        public async Task<SwitchDto> Edit(UpdateSwitchDto model)
        {
            var switchMap = _mapper.Map<Switch>(model);
            switchMap.CreatedAt = DateTime.UtcNow;
            switchMap.CreatedBy = "Administrator";
            await _switchRepository.Update(switchMap);
            var switchDtoMap = _mapper.Map<SwitchDto>(model);
            return switchDtoMap;
        }

        public async Task<SwitchDto> FindByIdAsync(int id)
        {
            var currentSwitch = await _switchRepository.FindById(id) ?? new Switch();
            var switchMap = _mapper.Map<SwitchDto>(currentSwitch);
            return switchMap;
        }

        public async Task<List<SwitchDto>> GetAll()
        {
            var listSwitch = await _switchRepository.GetAll() ?? new List<Switch>();
            var listSwitchMap = _mapper.Map<List<SwitchDto>>(listSwitch);
            return listSwitchMap;
        }
    }
}