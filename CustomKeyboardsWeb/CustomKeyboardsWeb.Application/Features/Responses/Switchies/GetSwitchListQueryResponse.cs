﻿using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class GetSwitchListQueryResponse : BaseHandlerResponse
    {
        public List<SwitchViewModel> Switchies { get; set; }

        public GetSwitchListQueryResponse()
            : base() { }

        public GetSwitchListQueryResponse(List<SwitchViewModel> switchViewModelList)
            : base() => Switchies = switchViewModelList;

        public GetSwitchListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}