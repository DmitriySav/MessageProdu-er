using System.Data.Entity;
using AzureConfig.Constant;
using AzureConfig.Models;

namespace AzureConfig.Context
{
    public class ConfigContext:DbContext
    {
        public ConfigContext(string connectingString):base(connectingString)
        {
            
        }
        /// <summary>
        /// Create instance with <c>"name=AppContext"</c> connection string
        /// </summary>
        public ConfigContext() : base(Constants.DbConnectionName)
        {

        }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }

    }
}
