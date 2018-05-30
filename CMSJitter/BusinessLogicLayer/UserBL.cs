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
    public class UserBL
    {
        public static Register UserRegistration(Register newRegister)
        {

            if (!USERDataLinker.IfEmailIsUnique(newRegister.Email))
            {
                // Email is not unique
                return null;
            }
            else
            {
                Register isUserAddedSuccessfully = USERDataLinker.AddUser(newRegister);
                //{
                //    //EmailId = email,
                //    //Password = password,
                //    //Username= userName,
                //    //FirstName = firstName,
                //    //LastName = lastName,
                //    //ImageUrl = imageURL,
                //    //MobileNo = phoneNumber,
                //    //Country = country
                //});
                if (isUserAddedSuccessfully != null)
                {
                    return isUserAddedSuccessfully;
                }
                else
                {
                    return null;
                }
            }
        }
        //public static Register UserRegisteration(string email, string password, string firstName, string lastName, byte[] image, int phoneNumber, string country)
        //{

        //    if (!UserDetailDll.IfEmailIsUnique(email))
        //    {
        //        // Email has been used
        //        return null;
        //    }
        //    else
        //    {
        //        Register isUserAddedSuccessfully = UserDetailDll.AddUser(new Register
        //        {
        //            Email = email,
        //            Password = password,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Image = image,
        //            MobileNumber = phoneNumber,
        //            Country = country
        //        });
        //        if (isUserAddedSuccessfully != null)
        //        {
        //            return isUserAddedSuccessfully;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        public static Login UserLogin(string email, string password)
        {
            if (USERDataLinker.IfEmailIsUnique(email))
            {
                return null;
            }
            else
            {
                int loginId = USERDataLinker.GetUserDetailId(email);
                Login userLoginDTO = USERDataLinker.GetUserInfo(new Login
                {
                    Email = email,
                    Password = password
                });

                if (userLoginDTO != null)
                {
                    return userLoginDTO;
                }
                else
                {
                    return null;
                }
            }
        }

        public static IList<TweetDTO> DisplayTweets(LoginFollowerDTO userTracks)
        {
            IList<UserDetails> followees = UserFollowerBL.GetFollowees(userTracks.Email, userTracks.Password, userTracks.FollowerId);
            IList<TweetDTO> playGroundTweets = new List<TweetDTO>();
            foreach (var followee in followees)
            {
                foreach (TweetDTO tweet in TweetBL.GetTweets(followee.UserId))
                {
                    playGroundTweets.Add(tweet);
                }
            }

            IList<TweetDTO> myTweets = TweetBL.GetTweets(userTracks.FollowerId);

            foreach (TweetDTO tweet in myTweets)
            {
                playGroundTweets.Add(tweet);
            }

            playGroundTweets.OrderByDescending(x => x.TweetId);
            return playGroundTweets;
        }
    }
}