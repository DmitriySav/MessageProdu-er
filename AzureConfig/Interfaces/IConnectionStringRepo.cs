using System;
using System.Collections.Generic;
using AzureConfig.Models;

namespace AzureConfig.Interfaces
{
    public interface IConnectionStringRepo : IDisposable
    {
        ConnectionString Add(ConnectionString item);
        IEnumerable<ConnectionString> GetAll();
        void Remove(int id);
    }
}