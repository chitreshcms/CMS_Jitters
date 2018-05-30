using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USERDataTransferObject;
namespace DataAccessLayer
{
    public class USERDataLinker
    {
        public static Register AddUser(Register register)
        {
            Register registerData = null;
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    User user = new User
                    {
                        Email = register.Email,
                        Password = register.Password,
                        FName = register.FName,
                        LName = register.LName,
                        Image = Enumerable.Repeat((byte)0x20, 10).ToArray(),
                        MobNumber = register.MobNumber,
                        Country = register.Country,
                        TotalTweets = register.TotalTweets
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    registerData = register;

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw (e);
            }

            return register;
        }

        public static Login GetUserInfo(Login login)
        {
            Login UserInfo = null;
            try
            {
                using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
                {
                    var user = (from users in context.Users
                                where users.Email == login.Email &&
                                users.Password == login.Password
                                select users).FirstOrDefault();

                    if (user != null)
                    {
                        UserInfo = new Login
                        {
                            Email = user.Email,
                            Password = user.Password
                        };
                    }
                    else
                    {
                        UserInfo = null;
                    }
                }
            }
            catch (NullReferenceException)
            {
                UserInfo = null;
            }

            return UserInfo;
        }



        public static bool IfEmailIsUnique(string email)
        {
            using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
            {
                var emailid = (from users in context.Users
                               where users.Email == email
                               select users.Email).FirstOrDefault();
                if (emailid == null)
                    return true;
                else
                    return false;
            }
        }


        public static IList<string> SearchUser(string searchString)
        {
            using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
            {
                var Fname = (from users in context.Users
                             where users.FName == searchString
                             select users.FName).ToList();
                if (Fname == null)
                    return null;
                else
                    return Fname;
            }
        }


        public static int GetUserDetailId(string emailId)
        {
            using (CMSTweetDBEntities111 context = new CMSTweetDBEntities111())
            {
                var userId = (from e in context.Users select e).Where(x => x.Email.Equals(emailId)).FirstOrDefault().UserId;
                return userId;
            }
        }
    }
}