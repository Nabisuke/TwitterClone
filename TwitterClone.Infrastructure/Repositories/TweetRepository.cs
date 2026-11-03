using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly List<Tweet> _tweets = new();

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            var existingTweet = _tweets.SingleOrDefault(t => t.Id == tweet.Id);
            if (existingTweet != null)
            {
                _tweets.Remove(existingTweet);
                _tweets.Add(tweet);
            }

            return tweet;
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweets.SingleOrDefault(t => t.Id == id);
            if (tweet == null)
            {
                return false;
            }

            _tweets.Remove(tweet);
            return true;
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(t => t.Id == id);
        }

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }
    }
}
