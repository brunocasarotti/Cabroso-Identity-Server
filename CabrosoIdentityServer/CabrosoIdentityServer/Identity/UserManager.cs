using Microsoft.AspNet.Identity;

namespace CabrosoIdentityServer.Identity
{
    public class UserManager : UserManager<User, string>
    {
        public UserManager(UserStore store) : base(store)
        {
        }
    }
}