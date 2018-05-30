using System;

namespace UserReactionDataTransferObject
{
    public class UserReactionDTO
    {
        public int UserReactionId { get; set; }
        public int UserId { get; set; }
        public int TweetId { get; set; }
        public int IsLiked { get; set; }
    }
}
