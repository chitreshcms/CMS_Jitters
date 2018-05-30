using System;

namespace USERDataTransferObject
{
    public class Register
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string MobNumber { get; set; }
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public string Password { get; set; }
        public int? TotalTweets { get; set; }

    }
}
