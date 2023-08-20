using CustomKeyboardsWeb.Application.Features.Commands.Members;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Members
{
    public class CreateMemberCommandValidation : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidation()
        {
            RuleFor(c => c.MemberViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
