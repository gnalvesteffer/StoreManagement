using static StoreManagement.Models.Utils.StoreCsvSerializationUtil;
using StoreManagement.Models.Data;
using StoreManagement.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Configuration;
using System.Web;

namespace StoreManagement.Models.Repositories
{
    public class StoreCsvRepository : IRepository<Store>
    {
        private static readonly ICollection<Store> _stores = DeserializeStores(File.ReadAllLines(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, ConfigurationManager.AppSettings["StoresCsvFilePath"])));

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