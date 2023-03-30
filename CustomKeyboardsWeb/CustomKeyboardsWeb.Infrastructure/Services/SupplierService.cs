using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Entity;

namespace MyHardwareWeb.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Save(SupplierDto model)
        {
            var supplierMap = _mapper.Map<Supplier>(model);
            await _supplierRepository.Create(supplierMap);
            return model;
        }

        public async Task<SupplierDto> Edit(SupplierDto model)
        {
            var supplierMap = _mapper.Map<Supplier>(model);
            await _supplierRepository.Update(supplierMap);
            return model;
        }

        public async Task<SupplierDto> FindByIdAsync(int id)
        {
            var currentSupplier = await _supplierRepository.FindById(id) ?? new Supplier();
            var supplierMap     = _mapper.Map<SupplierDto>(currentSupplier);
            return supplierMap;
        }

        public async Task<List<SupplierDto>> GetAll()
        {
            var listSupplier    = await _supplierRepository.GetAll() ?? new List<Supplier>();
            var listSupplierMap = _mapper.Map<List<SupplierDto>>(listSupplier);
            return listSupplierMap;
        }
    }
}