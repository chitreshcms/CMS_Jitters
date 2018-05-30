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
    public class UserController : ApiController
    {

        [HttpPost]
        public Register UserRegistration([FromBody]Register newRegister)
        {
            return UserBL.UserRegistration(newRegister);    
            //return UserBL.UserRegisteration(newRegister.Email, newRegister.Password, newRegister.FirstName, newRegister.LastName, newRegister.Image, newRegister.MobileNumber, newRegister.Country);
        }

        [HttpPost]
        public Login Login(Login newLogin)
        {
            return UserBL.UserLogin(newLogin.Email, newLogin.Password);
        }

        [HttpPost]
        public USERFollowerDTO AddFollower(LoginFollowerDTO trackUser)
        {
            return UserFollowerBL.AddFollower(trackUser.Email, trackUser.Password, trackUser.FollowerId, trackUser.UserId);
        }

        [HttpPost]
        public IList<UserDetails> GetFollowings(LoginFollowerDTO trackUser)
        {
            return UserFollowerBL.GetFollowees(trackUser.Email, trackUser.Password, trackUser.UserId);
        }

        [HttpPost]
        public IList<UserDetails> GetFollowers(LoginFollowerDTO trackUser)
        {
            return UserFollowerBL.GetFollowers(trackUser.Email, trackUser.Password, trackUser.UserId);
        }

        [HttpPost]
        public bool UnfollowUser(USERFollowerDTO newTrack)
        {
            return UserFollowerBL.UnFollow(newTrack);
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
