using CabrosoIdentityServer.Identity;
using IdentityManager;
using IdentityManager.Configuration;
using System.Data.Entity;

namespace CabrosoIdentityServer.IdentityManager
{
    public static class IdentityManagerServiceExtensions
    {
        public static void ConfigureIdentityManagerService(this IdentityManagerServiceFactory factory, string connectionString)
        {
            factory.Register(new Registration<DbContext>(resolver => new IdentityContext(connectionString)));
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<RoleStore>());
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<RoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, IdentityManagerService>();
        }
    }
}