using CabrosoIdentityServer.IdentityAdmin;
using CabrosoIdentityServer.IdentityManager;
using CabrosoIdentityServer.IdentityServer;
using IdentityAdmin.Configuration;
using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using Owin;
using System.Collections.Generic;

namespace CabrosoIdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityAdminServiceFactory();
                factory.Configure("AspId");

                adminApp.UseIdentityAdmin(new IdentityAdminOptions
                {
                    Factory = factory
                });
            });

            app.Map("/manager", managerApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureIdentityManagerService("AspId");

                managerApp.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });
            });

            app.Map("/core", core =>
            {
                var idSvrFactory = Factory.Configure("AspId");
                idSvrFactory.ConfigureUserService("AspId");

                var options = new IdentityServerOptions
                {
                    SiteName = "Cabroso Identity Server",
                    SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        LoginPageLinks = new List<LoginPageLink>
                        {
                           new LoginPageLink()
                           {
                               Href = "passwordReset",
                               Text = "Reset Your Password",
                               Type = ""
                           }
                        }
                    }
                };

                core.UseIdentityServer(options);
            });
        }
    }
}
