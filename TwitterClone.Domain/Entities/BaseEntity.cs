namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid? UpdatedBy { get; private set; }

        public BaseEntity(Guid id, Guid? createdBy = null)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy ?? Guid.Empty;
        }

        public virtual string DescribeRecord()
        {
            return $"Id: {Id}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}, CreatedBy: {CreatedBy}, UpdatedBy: {UpdatedBy}";
        }

    }
}