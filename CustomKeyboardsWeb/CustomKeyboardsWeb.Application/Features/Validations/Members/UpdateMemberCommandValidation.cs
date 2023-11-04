using CustomKeyboardsWeb.Application.Features.Commands.Members;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Members
{
    public class UpdateMemberCommandValidation : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidation()
        {
            RuleFor(c => c.MemberDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
