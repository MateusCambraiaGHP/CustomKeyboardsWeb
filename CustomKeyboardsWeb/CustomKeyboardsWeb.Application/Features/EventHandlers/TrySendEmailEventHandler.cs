using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Common.Interfaces;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace CustomKeyboardsWeb.Application.Features.EventHandlers
{
    public class TrySendEmailEventHandler : BaseEventHandler<TrySendEmailEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemberRepository _memberRepository;

        public TrySendEmailEventHandler(
            IEmailService emailService,
            IHttpContextAccessor httpContextAccessor,
            IMemberRepository memberRepository)
        {
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _memberRepository = memberRepository;
        }

        public override async Task Handle(TrySendEmailEvent notification, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var currentMember = await _memberRepository.GetAsync(mb => mb.Token == token, null, null);
            await _emailService.SendEmail(currentMember.FirstOrDefault().Email.Value, notification.BodyEmail);
        }

        protected override void PostErrorLog(string message)
        {
            throw new NotImplementedException();
        }

        protected override void PostInfoLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
