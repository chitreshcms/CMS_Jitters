using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USERFollowerDataTransferObject;
namespace DataAccessLayer
{
    public class USERFollowerDataLinker
    {
        public static USERFollowerDTO AddFollower(USERFollowerDTO userTrack)
        {
            USERFollowerDTO newFollowee = new USERFollowerDTO();
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    UserFollower followee = new UserFollower
                    {
                        FollowerId = userTrack.FollowerId,
                        UserId= userTrack.UserId
                    };
                    context.UserFollowers.Add(followee);
                    context.SaveChanges();

                    {
                        newFollowee.UserId = followee.UserId;
                        newFollowee.FollowerId = followee.FollowerId;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return newFollowee;
        }

        public static IList<USERDataTransferObject.UserDetails> GetFollowees(int ucid)
        {
            var list = new List<USERDataTransferObject.UserDetails>();
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var list1 = (from userConnection in context.UserFollowers
                                 where userConnection.FollowerId == ucid
                                 select userConnection).ToList();
                    list1.ForEach(item =>
                    {
                        list.Add(new USERDataTransferObject.UserDetails()
                        {
                            UserId = item.UserId,
                            FName = item.User.FName,
                            Image = item.User.Image
                        });
                    });
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

        public static IList<USERDataTransferObject.UserDetails> GetFollowers(int ucid)
        {
            var list = new List<USERDataTransferObject.UserDetails>();
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var list1 = (from userConnection in context.UserFollowers
                                 where userConnection.UserId == ucid
                                 select userConnection).ToList();
                    list1.ForEach(item =>
                    {
                        list.Add(new USERDataTransferObject.UserDetails()
                        {
                            UserId = item.FollowerId,
                            FName = item.User.FName,
                            Image = item.User.Image
                        });
                    });
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

        public static bool UnFollow(USERFollowerDTO followee)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var following = (from followings in context.UserFollowers
                                     where followings.FollowerId == followee.FollowerId &&
                                     followings.UserId == followee.UserId
                                     select followings).FirstOrDefault();
                    if (following == null)
                    {
                        return false;
                    }
                    context.UserFollowers.Remove(following);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckUserLoggedIn(string emailId, string password)
        {
            using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
            {
                var emailCheck = (from users in context.Users
                                  where users.Email == emailId
                                  select users.Email).ToList();
                var passwordCheck = (from users in context.Users
                                     where users.Password == password
                                     select users.Password).ToList();
                if (emailCheck.Count() != 0 && passwordCheck.Count() != 0)
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
}