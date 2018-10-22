using System;
using AzureConfig.Constant;

namespace AzureConfig.Models
{
    public class ConnectionString
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public EnvironmentEnum Environment { get; set; }

    }


    
}
