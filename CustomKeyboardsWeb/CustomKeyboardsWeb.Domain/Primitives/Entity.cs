using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity() { }

        public int Id { get; set; }
        public string Active { get; set; }
    }
}
