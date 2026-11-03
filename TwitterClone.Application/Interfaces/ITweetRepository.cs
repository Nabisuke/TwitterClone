using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetRepository
    {
        Tweet AddTweet(Tweet tweet);

        Tweet UpdateTweet(Tweet tweet);

        bool DeleteTweet(Guid id);

        Tweet? GetTweetById(Guid id);

        List<Tweet> GetTweets();
    }
}
