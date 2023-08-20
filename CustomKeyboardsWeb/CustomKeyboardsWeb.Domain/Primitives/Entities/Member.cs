using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public class Member : AggregateRoot
    {
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }

        public Member() { }

        private Member(
            Email email,
            Password password,
            Name name,
            Address address,
            Phone phone,
            string active,
            string createdBy,
            string? updatedBy)
        {
            Email = email;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Active = active;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
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
                active,
                "Administrator",
                null);
        }
    }
}
