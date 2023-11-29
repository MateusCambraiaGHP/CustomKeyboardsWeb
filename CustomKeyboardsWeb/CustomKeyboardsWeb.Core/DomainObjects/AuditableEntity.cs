namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class AuditableEntity
    {
        public bool IsDeleted { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public virtual void Delete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}
