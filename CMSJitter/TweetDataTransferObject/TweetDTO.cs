using System;

namespace TweetDataTransferObject
{
    public class TweetDTO
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string TweetContent { get; set; }
        public DateTime Date { get; set; }
    }
}
