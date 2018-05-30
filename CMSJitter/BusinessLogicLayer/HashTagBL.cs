using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class HashTagBL
    {
        private static IList<HashTagDTO> SplitHashtags(TweetDTO tweet)
        {
            IList<HashTagDTO> listOfHashTagsInMessage = new List<HashTagDTO>();
            var regex = new Regex(@"(?<=#)\w+");
            var hashTagsInMessage = regex.Matches(tweet.TweetContent);
            foreach (Match m in hashTagsInMessage)
            {
                var newhashtag = new HashTagDTO
                {
                    HashTagName = m.ToString(),
                    TweetId = tweet.TweetId,
                };
                listOfHashTagsInMessage.Add(newhashtag);
            }
            return listOfHashTagsInMessage;
        }

        public static bool AddHashTag(TweetDTO tweet)
        {
            IList<HashTagDTO> hashTagsInTheMessage = SplitHashtags(tweet);
            bool isAdded = HASHTAGDataLinker.AddToHashTagList(hashTagsInTheMessage);
            if (isAdded == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveHashTag(TweetDTO tweet)
        {
            //string message = tweet.Content;
            IList<HashTagDTO> hashTagsInThisMessage = SplitHashtags(tweet);
            bool isDeleted = HASHTAGDataLinker.DeleteFromHashTagList(hashTagsInThisMessage);
            if (isDeleted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}