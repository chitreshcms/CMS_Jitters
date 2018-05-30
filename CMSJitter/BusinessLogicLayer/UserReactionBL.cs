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
    public class UserReactionBL
    {
        public static bool Like(TweetDTO tweet)
        {
            UserReactionDTO like = new UserReactionDTO
            {
                UserId = tweet.UserId,
                TweetId = tweet.TweetId,
                IsLiked = 1
            };
            return USERReactionDataLinker.AddToLikes(like);
        }

        public static bool DisLike(TweetDTO tweet)
        {
            UserReactionDTO dislike = new UserReactionDTO
            {
                UserId = tweet.UserId,
                TweetId = tweet.TweetId,
                IsLiked = -1
            };
            return USERReactionDataLinker.AddToDislikes(dislike);
        }

        public static bool UndoResponse(TweetDTO tweet)
        {
            UserReactionDTO undo = new UserReactionDTO
            {
                UserId = tweet.UserId,
                TweetId = tweet.TweetId,

            };
            return USERReactionDataLinker.RemoveFromResponses(undo);
        }

        public static int NoOfLikes(int tweetid)
        {
            return USERReactionDataLinker.NoOfLikes(tweetid);
        }

        public static int NoOfDisLikes(int tweetid)
        {
            return USERReactionDataLinker.NoOfDisLikes(tweetid);
        }


    }
}