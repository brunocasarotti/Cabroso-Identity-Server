using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;

namespace CabrosoIdentityServer.IdentityAdmin
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService(string connectionString, string schema = null, bool createIfNotExist = false) : base(connectionString, schema, createIfNotExist)
        {
        }
    }
}