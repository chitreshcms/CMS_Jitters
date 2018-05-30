using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserReactionDataTransferObject;
namespace DataAccessLayer
{
    public class USERReactionDataLinker
    {
        public static bool AddToLikes(UserReactionDTO responseObject)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    context.UserReactions.Add(new UserReaction
                    {
                        UserReactionId = responseObject.UserReactionId,
                        UserId = responseObject.UserId,
                        IsLiked = 1
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveFromResponses(UserReactionDTO responseObject)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    //var react = context.Reacts.Find(reactObject.Id);
                    var react = context.UserReactions.FirstOrDefault(l => l.UserReactionId == responseObject.UserReactionId && l.UserId == responseObject.UserId);
                    context.UserReactions.Remove(react);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddToDislikes(UserReactionDTO responseObject)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    context.UserReactions.Add(new UserReaction
                    {
                        UserReactionId = responseObject.UserReactionId,
                        UserId = responseObject.UserId,
                        IsLiked = 1
                    });
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int NoOfLikes(int tweetid)
        {
            int count = 0;
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    count = (from responses in context.UserReactions
                             where responses.UserReactionId == tweetid && responses.IsLiked == 1
                             select responses.UserReactionId).ToList().Count;
                }
            }
            catch (Exception)
            {
            }
            return count;
        }

        public static int NoOfDisLikes(int tweetid)
        {
            int count = 0;
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    count = (from responses in context.UserReactions
                             where responses.UserReactionId == tweetid && responses.IsLiked == -1
                             select responses.UserReactionId).ToList().Count;
                }
            }
            catch (Exception)
            {
            }
            return count;
        }

    }
}