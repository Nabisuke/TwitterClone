namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public string Author { get; }
        public string Content { get; private set; } = string.Empty;

        public Tweet(string author, string content) : base(Guid.NewGuid())
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be empty or whitespace.", nameof(author));
            }
            Author = author;
            SetContent(content, Guid.Empty);
        }

        public void SetContent(string content, Guid updatedByUserId)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Content cannot be empty or whitespace.", nameof(content));
            }
            if (content.Length > 280)
            {
                throw new ArgumentException("Content cannot exceed 280 characters.", nameof(content));
            }
            Content = content;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedByUserId;
        }

    }
}