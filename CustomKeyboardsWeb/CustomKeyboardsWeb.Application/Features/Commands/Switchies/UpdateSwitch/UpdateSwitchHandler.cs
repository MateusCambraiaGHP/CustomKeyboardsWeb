using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies.UpdateSwitch
{
    public class UpdateSwitchHandler : IRequestHandler<UpdateSwitchCommand, SwitchDto>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSwitchHandler(
            ISwitchRepository switchRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _switchRepository = switchRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SwitchDto> Handle(UpdateSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var switchMap = _mapper.Map<Switch>(request.SwitchDto);
                switchMap.CreatedAt = DateTime.UtcNow;
                switchMap.CreatedBy = "Administrator";
                await _switchRepository.Update(switchMap);
                await _unitOfWork.CommitChangesAsync();
                var switchDtoMap = _mapper.Map<SwitchDto>(request.SwitchDto);
                return switchDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
