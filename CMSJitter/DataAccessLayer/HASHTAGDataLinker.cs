using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HASHTAGDataTransferObject;
namespace DataAccessLayer
{
    public class HASHTAGDataLinker
    {
        public static bool AddToHashTagList(IList<HashTagDTO> listOFHashTags)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    foreach (HashTagDTO hashtag in listOFHashTags)
                    {
                        HashTag newHashtag = context.HashTags.FirstOrDefault(a => a.HashTagName == hashtag.HashTagName);

                        context.HashTags.Add(new HashTag
                        {
                            HashTagName = newHashtag.HashTagName,
                            TweetId = newHashtag.TweetId
                        });

                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteFromHashTagList(IList<HashTagDTO> listOFHashTags)
        {
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    foreach (HashTagDTO hashtag in listOFHashTags)
                    {
                        HashTag newHashtag = context.HashTags.FirstOrDefault(a => a.HashTagName == hashtag.HashTagName && a.TweetId == hashtag.TweetId);
                        //if a hashtag already exists
                        if (newHashtag != null)
                        {
                            context.HashTags.Remove(newHashtag);
                        }
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}