using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CabrosoIdentityServer.Identity
{
    public class UserStore : UserStore<User, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UserStore(DbContext context) : base(context)
        {
        }
    }
}