using AutoMapper;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer;
using CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey;
using CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Keyboard.Commands.UpdateKeyboard;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Supplier.Commands.UpdateSupplier;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch;
using CustomKeyboardsWeb.Domain.Primitives;
using Switch = CustomKeyboardsWeb.Domain.Primitives.Switch;

namespace CustomKeyboardsWeb.Infrastructure.Common.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, CustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();
            CreateMap<Keyboard, KeyboardDto>();
            CreateMap<KeyboardDto, Keyboard>();
            CreateMap<CreateKeyboardDto, KeyboardDto>();
            CreateMap<CreateKeyboardDto, Keyboard>();
            CreateMap<UpdateKeyboardDto, KeyboardDto>();
            CreateMap<UpdateKeyboardDto, Keyboard>();
            CreateMap<Key, KeyDto>();
            CreateMap<KeyDto, Key>();
            CreateMap<CreateKeyDto, KeyDto>();
            CreateMap<CreateKeyDto, Key>();
            CreateMap<UpdateKeyDto, KeyDto>();
            CreateMap<UpdateKeyDto, Key>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<CreateSupplierDto, SupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, SupplierDto>();
            CreateMap<UpdateSupplierDto, Supplier>();
            CreateMap<Switch, SwitchDto>();
            CreateMap<SwitchDto, Switch>();
            CreateMap<CreateSwitchDto, SwitchDto>();
            CreateMap<CreateSwitchDto, Switch>();
            CreateMap<UpdateSwitchDto, SwitchDto>();
            CreateMap<UpdateSwitchDto, Switch>();
        }
    }
}
