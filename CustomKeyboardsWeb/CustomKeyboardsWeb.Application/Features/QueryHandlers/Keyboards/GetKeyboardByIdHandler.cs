﻿using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keyboards
{
    public class GetKeyboardByIdHandler : Handler<GetKeyboardByIdQuery, GetKeyboardByIdQueryResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;

        public GetKeyboardByIdHandler(
            IKeyboardRepository keyboardRepository,
            IMapper mapper)
            :base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
        }

        public override async Task<GetKeyboardByIdQueryResponse> Handle(GetKeyboardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var currentKeyboard = await _keyboardRepository.FindById(request.IdKeyboard);
                var keyboardMap = _mapper.Map<KeyboardViewModel>(currentKeyboard);

                return new GetKeyboardByIdQueryResponse(keyboardMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<List<ValidationFailure>> Validate(GetKeyboardByIdQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
