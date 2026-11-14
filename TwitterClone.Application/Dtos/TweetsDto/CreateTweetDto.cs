namespace TwitterClone.Application.Dtos.TweetsDto
{
    public class CreateTweetDto
    {
        public required Guid UserId { get; set; }
        public required string Content { get; set; }
    }
}
