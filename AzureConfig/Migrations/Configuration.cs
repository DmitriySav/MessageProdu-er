using System;
using System.Data.Entity.Migrations;
using AzureConfig.Constant;
using AzureConfig.Context;
using AzureConfig.Models;

namespace AzureConfig.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ConfigContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConfigContext context)
        {
            ConnectionString con1 = new ConnectionString
            {
                Name = "myqueue",
                Value = "UseDevelopmentStorage=true",
                CreatedAtUtc = DateTime.Now,
                Environment = EnvironmentEnum.Development
            };
            context.ConnectionStrings.Add(con1);
            context.SaveChanges();
        }
    }
}
