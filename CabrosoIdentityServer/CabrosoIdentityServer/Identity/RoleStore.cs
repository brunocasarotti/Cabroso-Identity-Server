using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CabrosoIdentityServer.Identity
{
    public class RoleStore : RoleStore<IdentityRole>
    {
        public RoleStore(DbContext ctx)
            : base(ctx)
        {
        }
    }
}