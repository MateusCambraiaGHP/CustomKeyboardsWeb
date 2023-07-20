namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity() { }

        public int Id { get; set; }
        public string Active { get; set; }
    }
}
