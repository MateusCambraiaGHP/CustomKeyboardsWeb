using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Members
{
    public class Member : AggregateRoot
    {
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public string? Token { get; private set; }

        public Member() { }

        private Member(
            Email email,
            Password password,
            Name name,
            Address address,
            Phone phone,
            string active)
        {
            Email = email;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Active = active;
        }

        public static Member Create(
            Email email,
            Password password,
            Name name,
            Address address,
            Phone phone,
            string active)
        {
            return new Member(
                email,
                password,
                name,
                address,
                phone,
                active);
        }

        public void SetToken(string token) => Token = token;
    }
}
