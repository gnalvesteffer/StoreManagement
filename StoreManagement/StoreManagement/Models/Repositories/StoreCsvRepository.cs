using static StoreManagement.Models.Utils.StoreCsvSerializationUtil;
using StoreManagement.Models.Data;
using StoreManagement.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Configuration;

namespace StoreManagement.Models.Repositories
{
    public class StoreCsvRepository : IRepository<Store>
    {
        private readonly string _storeCsvFilePath;
        private static readonly ICollection<Store> _stores = DeserializeStores(File.ReadAllLines(ConfigurationManager.AppSettings["StoresCsvFilePath"]));

        public void Add(Store entity)
        {
            _stores.Add(entity);
        }

        public void Delete(Store entity)
        {
            _stores.Remove(entity);
        }

        public IQueryable<Store> GetAll()
        {
            return _stores.AsQueryable();
        }

        public void SaveChanges()
        {
            File.WriteAllText(ConfigurationManager.AppSettings["StoresCsvFilePath"], SerializeStores(_stores.ToArray()));
        }
    }
}