using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetDataTransferObject;
namespace DataAccessLayer
{
    public class TWEETDataLinker
    {

        public static TweetDTO AddTweet(TweetDTO tweetObject)
        {
            TweetDTO newTweet = null;
            try
            {
                using (CMSTweetDBEntities111  context = new CMSTweetDBEntities111())
                {
                    Tweet tweet = new Tweet
                    {
                        TweetContent = tweetObject.TweetContent,
                        UserId = tweetObject.UserId,
                        Date = tweetObject.Date
                    };
                    context.Tweets.Add(tweet);
                    if (context.SaveChanges() > 0)
                    {
                        newTweet = tweetObject;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return newTweet;
        }

        public static List<TweetDTO> GetTweets(int followingId)
        {
            var oldTweet = new List<TweetDTO>();

            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {

                    var Ucontent = (from tweets in context.Tweets
                                    where tweets.UserId == followingId
                                    select tweets).ToList();

                    Ucontent.ForEach(y =>
                    {
                        oldTweet.Add(new TweetDTO()
                        {
                            TweetContent = y.TweetContent
                        });
                    });

                    return oldTweet;

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return oldTweet;
        }

        public static TweetDTO EditTweet(TweetDTO editedTweet)
        {
            TweetDTO newtweet = null;
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var tweet = context.Tweets.Find(editedTweet.TweetId);
                    tweet.TweetContent = editedTweet.TweetContent;
                    tweet.Date = editedTweet.Date;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
            return newtweet;
        }

        public static bool DeleteTweet(TweetDTO tweettoDelete)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var tweet = context.Tweets.Find(tweettoDelete.TweetId);
                    context.Tweets.Remove(tweet);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}