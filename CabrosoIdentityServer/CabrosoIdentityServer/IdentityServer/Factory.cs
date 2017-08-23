using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.EntityFramework;

namespace CabrosoIdentityServer.IdentityServer
{
    class Factory
    {
        public static IdentityServerServiceFactory Configure(string connStr)
        {
            var factory = new IdentityServerServiceFactory();

            var efConfig = new EntityFrameworkServiceOptions
            {
                ConnectionString = connStr,
                //Schema = Constants.IdentityServerSchema
            };

            factory.RegisterConfigurationServices(efConfig);
            factory.RegisterOperationalServices(efConfig);

            factory.CorsPolicyService = new Registration<ICorsPolicyService>(new DefaultCorsPolicyService { AllowAll = true });

            return factory;
        }
    }
}