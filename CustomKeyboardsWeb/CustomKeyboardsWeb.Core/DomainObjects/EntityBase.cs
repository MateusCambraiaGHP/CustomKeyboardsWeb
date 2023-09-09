namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class EntityBase : Entity
    {
        public DateTime InsertionDate { get; protected set; }
        public DateTime LastModification { get; protected set; }

        public void SetInsertionDate(DateTime insertionDate) =>
            InsertionDate = insertionDate;

        public void SetLastModification(DateTime lastModification) =>
            LastModification = lastModification;
    }
}
