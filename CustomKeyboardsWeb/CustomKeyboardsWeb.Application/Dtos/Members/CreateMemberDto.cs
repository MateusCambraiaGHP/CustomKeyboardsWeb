namespace CustomKeyboardsWeb.Application.Dtos.Members
{
    public class CreateMemberDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Active { get; set; }
        public string Phone { get; set; }
    }
}
