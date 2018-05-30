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
    public class UserFollowerBL
    {
        public static USERFollowerDTO AddFollower(string email, string password, int followerid, int followingid)
        {
            if (!USERFollowerDataLinker.CheckUserLoggedIn(email, password))
            {
                //If user is not logged in
                return null;
            }
            else
            {
                USERFollowerDTO userdto = new USERFollowerDTO()
                {
                    FollowerId = followerid,
                    UserId = followingid
                };

                USERFollowerDTO addFollowing = USERFollowerDataLinker.AddFollower(userdto);

                if (addFollowing != null)
                {
                    return addFollowing;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<UserDetails> GetFollowees(string email, string password, int followerId)
        {
            if (!USERFollowerDataLinker.CheckUserLoggedIn(email, password))
            {
                //If user is not logged in
                return null;
            }
            else
            {
                USERFollowerDTO obj = new USERFollowerDTO()
                {
                    FollowerId = followerId
                };
                IList<UserDetails> getFollowees = USERFollowerDataLinker.GetFollowees(obj.FollowerId);
                if (getFollowees != null)
                {
                    return getFollowees;
                }
                else
                {
                    return null;
                }
            }
        }
        public static IList<UserDetails> GetFollowers(string email, string password, int followeeid)
        {
            if (!USERFollowerDataLinker.CheckUserLoggedIn(email, password))
            {
                //User logged out
                return null;
            }
            else
            {
                USERFollowerDTO obj = new USERFollowerDTO()
                {
                    UserId = followeeid
                };
                IList<UserDetails> getFollowers = USERFollowerDataLinker.GetFollowers(obj.UserId);
                if (getFollowers != null)
                {
                    return getFollowers;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool UnFollow(USERFollowerDTO newTrack)
        {
            //if (!USERFollowerDataLinker.CheckUserLoggedIn(email, password))
            //{
            //    //User logged out
            //    return false;
            //}

            USERFollowerDTO followee = new USERFollowerDTO
            {
                UserId = newTrack.FollowerId,
                FollowerId = newTrack.UserId
            };
            return USERFollowerDataLinker.UnFollow(followee);
        }
    }
}