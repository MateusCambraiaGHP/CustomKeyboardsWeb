namespace CustomKeyboardsWeb.Core.DomainObjects
{
    public abstract class EntityBase : Entity
    {
        public DateTime InsertionDate { get; protected set; }
        public string InsertionBy { get; protected set; } = null!;
        public DateTime LastModification { get; protected set; }
        public string? ModificationBy { get; protected set; }

        public void SetInsertionDate(DateTime insertionDate, string insertionBy)
        {
            InsertionDate = insertionDate;
            InsertionBy = insertionBy;
        }

        public void SetLastModification(DateTime lastModification, string modificationBy)
        {
            LastModification = lastModification;
            ModificationBy = modificationBy;
        }
    }
}
