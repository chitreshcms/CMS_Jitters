using System;

namespace LOGINFollowerDataTransferObject
{
    public class LoginFollowerDTO
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
