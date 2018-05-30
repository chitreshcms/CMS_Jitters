using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using HASHTAGDataTransferObject;
using LOGINFollowerDataTransferObject;
using TweetDataTransferObject;
using USERDataTransferObject;
using USERFollowerDataTransferObject;
using UserReactionDataTransferObject;

namespace CMSJitter.Controllers
{
    public class TweetController : ApiController
    {

        [HttpPost]
        public TweetDTO AddTweet([FromBody]TweetDTO tweetDTO)
        {
            TweetDTO tweetObject = new TweetDTO();

            tweetObject = TweetBL.AddTweet(tweetDTO.UserId, tweetDTO.TweetContent);

            return tweetObject;
        }

        [HttpGet]
        public IList<TweetDTO> GetUserTweets(int id)
        {
            IList<TweetDTO> listOfTweets = new List<TweetDTO>();

            listOfTweets = TweetBL.GetTweets(id);

            return listOfTweets;
        }

        [HttpPost]
        public bool DeleteTweet(TweetDTO tweetObj)
        {
            return TweetBL.DeleteTweet(tweetObj);
        }

        [HttpPost]
        public TweetDTO EditTweet(TweetDTO tweetObj1, TweetDTO tweetObj2)
        {
            return TweetBL.EditTweet(tweetObj1, tweetObj2);
        }

        [HttpPost]
        public IList<TweetDTO> DisplayTweets(LoginFollowerDTO userTracks)
        {
            return UserBL.DisplayTweets(userTracks);
        }

        [HttpPost]
        public bool AddHashTag(TweetDTO addHash)
        {
            return HashTagBL.AddHashTag(addHash);
        }

        [HttpPost]
        public bool RemoveHashTag(TweetDTO removeHash)
        {
            return HashTagBL.RemoveHashTag(removeHash);
        }

        [HttpPost]
        public bool LikeTweet(TweetDTO likeTweet)
        {
            return UserReactionBL.Like(likeTweet);
        }

        [HttpPost]
        public bool DislikeTweet(TweetDTO disLikeTweet)
        {
            return UserReactionBL.DisLike(disLikeTweet);
        }

        [HttpPost]
        public bool UndoAction(TweetDTO actionTweet)
        {
            return UserReactionBL.UndoResponse(actionTweet);
        }

        [HttpGet]
        public int NoOfLikes(int tweetId)
        {
            return UserReactionBL.NoOfLikes(tweetId);
        }

        [HttpGet]
        public int NoOfDislikes(int tweetId)
        {
            return UserReactionBL.NoOfDisLikes(tweetId);
        }


        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
