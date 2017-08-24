using CabrosoIdentityServer.Identity;
using IdentityManager.AspNetIdentity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CabrosoIdentityServer.IdentityManager
{
    public class IdentityManagerService : AspNetIdentityManagerService<User, string, IdentityRole, string>
    {
        public IdentityManagerService(UserManager userMgr, RoleManager roleMgr)
            : base(userMgr, roleMgr)
        {

        }
    }
}