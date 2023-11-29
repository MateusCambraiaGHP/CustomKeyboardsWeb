using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class Entity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Active { get; set; }
        private List<Event> _eventNotifications;
        public IReadOnlyCollection<Event> EventNotifications => _eventNotifications?.AsReadOnly();

        protected Entity() => Guid.NewGuid();

        public void AddEvent(Event uniqueEvent)
        {
            _eventNotifications = _eventNotifications ?? new List<Event>();
            _eventNotifications.Add(uniqueEvent);
        }

        public void RemoveEvent(Event uniqueEvent) => _eventNotifications?.Remove(uniqueEvent);

        public void ClearEvents() => _eventNotifications?.Clear();

        public override bool Equals(object obj)
        {
            Entity entity = obj as Entity;
            if ((object)this == entity)
            {
                return true;
            }

            if ((object)entity == null)
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => GetType().GetHashCode() * 907 + Id.GetHashCode();

        public override string ToString() => GetType().Name + " [Id=" + Id.ToString() + "]";
    }
}
