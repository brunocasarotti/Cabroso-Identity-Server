using CabrosoIdentityServer.Identity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using System.Data.Entity;

namespace CabrosoIdentityServer.IdentityServer
{
    static class UserServiceExtensions
    {
        public static void ConfigureUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, UserService>();
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<DbContext>(resolver => new IdentityContext(connString)));
        }
    }
}