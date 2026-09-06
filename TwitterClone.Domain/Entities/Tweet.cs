namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikeable
    {
        public string Author { get; }
        public string Content { get; private set; } = string.Empty;
        public static int MaxContentLength => 200;

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
            if (content.Length > MaxContentLength)
            {
                throw new ArgumentException($"Content cannot exceed {MaxContentLength} characters.", nameof(content));
            }
            Content = content;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedByUserId;
        }

        public bool CanBeLiked()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                return false;
            }
            return true;
        }

    }
}