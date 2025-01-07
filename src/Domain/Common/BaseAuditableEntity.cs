namespace MyProject.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        protected BaseAuditableEntity() : base()
        {
            Created = DateTime.Now;
        }
        public DateTime Created { get; set; }
    }
}