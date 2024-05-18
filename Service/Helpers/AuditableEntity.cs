namespace TaskManagement.Service.Helpers
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

    }
}
