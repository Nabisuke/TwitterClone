using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly int _maxTweetLength;

        public TweetService(ITweetRepository tweetRepository, int maxTweetLength)
        {
            _tweetRepository = tweetRepository;
            _maxTweetLength = maxTweetLength;
        }

        public List<TweetDto> GetTweets()
        {
            return _tweetRepository.GetTweets()
                .Select(MapToDto)
                .ToList();
        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return tweet == null ? null : MapToDto(tweet);
        }

        public TweetDto? CreateTweet(CreateTweetDto createTweetDto)
        {
            if (!IsValidContent(createTweetDto.Content))
            {
                return null;
            }

            var tweet = new Tweet(createTweetDto.UserId, createTweetDto.Content);
            _tweetRepository.AddTweet(tweet);

            return MapToDto(tweet);
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null || !IsValidContent(updateTweetDto.Content))
            {
                return null;
            }

            tweet.AddContent(updateTweetDto.Content);
            _tweetRepository.UpdateTweet(tweet);

            return MapToDto(tweet);
        }

        public bool DeleteTweet(Guid id)
        {
            return _tweetRepository.DeleteTweet(id);
        }

        private bool IsValidContent(string content)
        {
            return !string.IsNullOrWhiteSpace(content) &&
                   content.Length <= _maxTweetLength;
        }

        private static TweetDto MapToDto(Tweet tweet)
        {
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
        }
    }
}
