﻿using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Keys
{
    public class CreateKeyCommandResponse : BaseHandlerResponse
    {
        public KeyViewModel Key { get; set; }

        public CreateKeyCommandResponse() { }

        public CreateKeyCommandResponse(KeyViewModel key)
            : base() => Key = key;

        public CreateKeyCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
