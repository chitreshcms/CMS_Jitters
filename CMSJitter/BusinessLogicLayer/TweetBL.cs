using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using HASHTAGDataTransferObject;
using LOGINFollowerDataTransferObject;
using TweetDataTransferObject;
using USERDataTransferObject;
using USERFollowerDataTransferObject;
using UserReactionDataTransferObject;
namespace BusinessLogicLayer
{
    public class TweetBL
    {
        public static TweetDTO AddTweet(int userid, string content)
        {
            {
                TweetDTO tweets = new TweetDTO()
                {
                    TweetContent = content,
                    UserId = userid,
                    Date = DateTime.Now
                };

                TweetDTO addTweet = TWEETDataLinker.AddTweet(tweets);

                if (addTweet != null)
                {
                    return addTweet;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<TweetDTO> GetTweets(int id)
        {
            IList<TweetDTO> getTweets = TWEETDataLinker.GetTweets(id);
            if (getTweets != null)
            {
                return getTweets;
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteTweet(TweetDTO tweet)
        {
            if (HashTagBL.RemoveHashTag(tweet))
            {
                if (UserReactionBL.UndoResponse(tweet))
                {
                    return TWEETDataLinker.DeleteTweet(tweet);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static TweetDTO EditTweet(TweetDTO beforeedit, TweetDTO afteredit)
        {
            if (HashTagBL.RemoveHashTag(beforeedit))
            {
                if (HashTagBL.AddHashTag(afteredit))
                {
                    return TWEETDataLinker.EditTweet(afteredit);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}