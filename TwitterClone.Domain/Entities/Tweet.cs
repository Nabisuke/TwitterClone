namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        private Guid _id;
        public string Author { get; }
        public string Content { get; private set; }

        public Tweet(string author, string content)
        {
            _id = Guid.NewGuid();
            Author = author;
            Content = content;
        }

        public void SetContent(string content)
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
        }



    }
}