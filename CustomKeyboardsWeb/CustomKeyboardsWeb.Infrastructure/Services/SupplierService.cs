using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.UpdateSupplier;
using CustomKeyboardsWeb.Domain.Primitives;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> Save(CreateSupplierDto model)
        {
            try
            {
                var supplier = Supplier.Create(
               Name.Create(model.Name),
               FantasyName.Create(model.FantasyName),
               Cep.Create(model.Cep),
               Address.Create(model.Adress),
               FederativeUnit.Create(model.FederativeUnit),
               Phone.Create(model.Phone),
               model.Active);

                await _supplierRepository.Create(supplier);
                await _unitOfWork.CommitChangesAsync();
                var supplierDto = _mapper.Map<SupplierDto>(supplier);
                return supplierDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SupplierDto> Edit(UpdateSupplierDto model)
        {
            try
            {
                var supplierMap = _mapper.Map<Supplier>(model);
                supplierMap.CreatedAt = DateTime.UtcNow;
                supplierMap.CreatedBy = "Administrator";
                await _supplierRepository.Update(supplierMap);
                await _unitOfWork.CommitChangesAsync();
                var supplierDtoMap = _mapper.Map<SupplierDto>(model);
                return supplierDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SupplierDto> FindByIdAsync(int id)
        {
            var currentSupplier = await _supplierRepository.FindById(id);
            var supplierMap = _mapper.Map<SupplierDto>(currentSupplier);
            return supplierMap;
        }

        public async Task<List<SupplierDto>> GetAll()
        {
            var listSupplier = await _supplierRepository.GetAll() ?? new List<Supplier>();
            var listSupplierMap = _mapper.Map<List<SupplierDto>>(listSupplier);
            return listSupplierMap;
        }
    }
}