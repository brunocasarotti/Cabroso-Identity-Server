using System;
using CabrosoIdentityServer.Identity;
using IdentityServer3.AspNetIdentity;

namespace CabrosoIdentityServer.IdentityServer
{
    public class UserService : AspNetIdentityUserService<User, string>
    {
        public UserService(UserManager userManager, Func<string, string> parseSubject = null) : base(userManager, parseSubject)
        {
        }
    }
}