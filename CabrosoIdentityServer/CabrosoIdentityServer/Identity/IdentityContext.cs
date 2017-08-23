using Microsoft.AspNet.Identity.EntityFramework;

namespace CabrosoIdentityServer.Identity
{
    public class IdentityContext : IdentityDbContext<User, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public IdentityContext(string connString) : base(connString)
        {

        }
    }
}