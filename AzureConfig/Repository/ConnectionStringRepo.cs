using System;
using System.Collections.Generic;
using AzureConfig.Context;
using AzureConfig.Interfaces;
using AzureConfig.Models;

namespace AzureConfig.Repository
{
    public class ConnectionStringRepo: IConnectionStringRepo
    {
        private ConfigContext db;

        public ConnectionStringRepo(ConfigContext context)
        {
            db = context;
        }

        public ConnectionString Add(ConnectionString item)
        {
            db.ConnectionStrings.Add(item);
            db.SaveChanges();
            return item;
        }

        public IEnumerable<ConnectionString> GetAll()
        {
            return db.ConnectionStrings;
        }

        public void Remove(int id)
        {
            var connectionString = db.ConnectionStrings.Find(id);
            if (connectionString == null) { throw new Exception($"ConnectionString with id={id} does not exist");}
            db.ConnectionStrings.Remove(connectionString);
            db.SaveChanges();

        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
