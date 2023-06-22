using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.CreateSwitch
{
    public class CreateSwitchHandler : IRequestHandler<CreateSwitchCommand, SwitchDto>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSwitchHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SwitchDto> Handle(CreateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var _switch = Switch.Create(
                    Name.Create(request.SwitchDto.Name),
                    Color.Create(request.SwitchDto.Color),
                    Price.Create(request.SwitchDto.Price),
                    request.SwitchDto.Active);

                await _switchRepository.Create(_switch);
                await _unitOfWork.CommitChangesAsync();
                var switchDto = _mapper.Map<SwitchDto>(_switch);
                return switchDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
