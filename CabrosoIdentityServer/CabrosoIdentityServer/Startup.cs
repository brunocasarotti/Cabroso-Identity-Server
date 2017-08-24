using Owin;
using IdentityServer3.Core.Configuration;
using CabrosoIdentityServer.IdentityServer;
using System.Collections.Generic;
using IdentityManager.Configuration;
using CabrosoIdentityServer.IdentityManager;

namespace CabrosoIdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
                var idSvrFactory = IdentityServer.Factory.Configure("AspId");
                idSvrFactory.ConfigureUserService("AspId");

                var options = new IdentityServerOptions
                {
                    SiteName = "Cabroso Identity Server",
                    SigningCertificate = IdentityServer.Certificate.Get(),
                    Factory = idSvrFactory,
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        LoginPageLinks = new List<LoginPageLink>
                        {
                           new LoginPageLink()
                           {
                               Href = "passwordReset",
                               Text = "Reset Your Password",
                               Type = "resetTestType"
                           }
                        }
                    }
                };

                core.UseIdentityServer(options);
            });
        }
    }
}
