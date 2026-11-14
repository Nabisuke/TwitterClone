using TwitterClone.Application.Dtos.TweetsDto;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        List<TweetDto> GetTweets();

        TweetDto? GetTweetById(Guid id);

        TweetDto? CreateTweet(CreateTweetDto createTweetDto);

        TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto);

        bool DeleteTweet(Guid id);
    }
}
