using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity() { }

        public int Id { get; set; }
        public string Active { get; set; }
        private List<Event> _eventNotifications;
        public IReadOnlyCollection<Event> EventNotifications => _eventNotifications?.AsReadOnly();

        public void AddEvent(Event uniqueEvent)
        {
            _eventNotifications = _eventNotifications ?? new List<Event>();
            _eventNotifications.Add(uniqueEvent);
        }

        public void RemoveEvent(Event uniqueEvent)
        {
            _eventNotifications?.Remove(uniqueEvent);
        }

        public void ClearEvents()
        {
            _eventNotifications?.Clear();
        }
    }
}
