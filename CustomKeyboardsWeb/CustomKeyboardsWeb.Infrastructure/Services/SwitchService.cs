using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives;

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

        public async Task<SwitchDto> Save(SwitchDto model)
        {
            var switchMap = _mapper.Map<Switch>(model);
            await _switchRepository.Create(switchMap);
            return model;
        }

        public async Task<SwitchDto> Edit(SwitchDto model)
        {
            var switchMap = _mapper.Map<Switch>(model);
            await _switchRepository.Update(switchMap);
            return model;
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