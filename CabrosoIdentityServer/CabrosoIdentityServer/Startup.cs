using Owin;
using IdentityServer3.Core.Configuration;
using CabrosoIdentityServer.IdentityServer;
using System.Collections.Generic;

namespace CabrosoIdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
