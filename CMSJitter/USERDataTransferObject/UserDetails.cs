using System;
using System.Collections.Generic;
using System.Text;

namespace USERDataTransferObject
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public byte[] Image { get; set; }
    }
}
