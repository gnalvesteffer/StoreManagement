using StoreManagement.Models.Data;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using static StoreManagement.Models.Utils.StoreCsvSerializationUtil;

namespace StoreManagement.Models.Repositories
{
    public class StoreCsvRepository : IRepository<Store>
    {
        private readonly ICollection<Store> _stores = DeserializeStores(File.ReadAllLines(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["StoresCsvFilePath"])));

        public void Add(Store entity)
        {
            var existingStore = _stores.FirstOrDefault(x => x.StoreNumber == entity.StoreNumber);
            if (existingStore != null)
            {
                _stores.Remove(existingStore);
            }
            if (entity.StoreNumber == null) entity.StoreNumber = _stores.Max(x => x.StoreNumber) + 1;
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
            File.WriteAllText(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["StoresCsvFilePath"]), SerializeStores(_stores.ToArray()));
        }
    }
}