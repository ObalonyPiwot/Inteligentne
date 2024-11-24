namespace MyProject.Domain.Common
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
