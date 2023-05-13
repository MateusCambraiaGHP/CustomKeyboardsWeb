using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class PuchaseHistoryService : IPuchaseHistoryService
    {
        private readonly IPuchaseHistoryRepository _puchaseHistoryRepository;
        private readonly IMapper _mapper;

        public PuchaseHistoryService(
            IPuchaseHistoryRepository puchaseHistoryRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _puchaseHistoryRepository = puchaseHistoryRepository;
        }

        public async Task<PuchaseHistoryDto> Save(PuchaseHistoryDto model)
        {
            var puchaseHistory = PuchaseHistory.Create(
                model.IdCustomer,
                model.IdSupplier,
                model.IdKeyboard,
                Price.Create(model.Price),
                model.Active);

            await _puchaseHistoryRepository.Create(puchaseHistory);
            var puchaseHistoryDto = _mapper.Map<PuchaseHistoryDto>(puchaseHistory);
            return puchaseHistoryDto;
        }

        public async Task<PuchaseHistoryDto> Edit(PuchaseHistoryDto model)
        {
            var puchaseHistoryMap = _mapper.Map<PuchaseHistory>(model);
            await _puchaseHistoryRepository.Update(puchaseHistoryMap);
            return model;
        }

        public async Task<PuchaseHistoryDto> FindByIdAsync(int id)
        {
            var currentPuchaseHistory = await _puchaseHistoryRepository.FindById(id);
            var puchaseHistoryMap = _mapper.Map<PuchaseHistoryDto>(currentPuchaseHistory);
            return puchaseHistoryMap;
        }

        public async Task<List<PuchaseHistoryDto>> GetAll()
        {
            var listPuchaseHistory = await _puchaseHistoryRepository.GetAll() ?? new List<PuchaseHistory>();
            var listPuchaseHistoryMap = _mapper.Map<List<PuchaseHistoryDto>>(listPuchaseHistory);
            return listPuchaseHistoryMap;
        }
    }
}