using System.ComponentModel.DataAnnotations.Schema;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities
{
    public abstract class Entity
    {
        protected Entity() { }

        public int Id { get; set; }
        public string Active { get; set; }
    }
}
