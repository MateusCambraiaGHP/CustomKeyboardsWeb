using CustomKeyboardsWeb.Application.Features.ViewModel.Commom;

namespace CustomKeyboardsWeb.Application.Features.ViewModel.Members
{
    public class MemberViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
