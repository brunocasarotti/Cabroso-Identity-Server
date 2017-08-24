using IdentityAdmin.Configuration;
using IdentityAdmin.Core;

namespace CabrosoIdentityServer.IdentityAdmin
{
    public static class IdentityAdminServiceExtensions
    {
        public static void Configure(this IdentityAdminServiceFactory factory, string connString)
        {
            factory.IdentityAdminService = new Registration<IIdentityAdminService>(resolver => new IdentityAdminManagerService(connString));
        }
    }
}