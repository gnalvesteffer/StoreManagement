using StoreManagement.Models.Data;
using StoreManagement.Models.Forms;
using StoreManagement.Models.Repositories;
using StoreManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace StoreManagement.Models.Services
{
    public class StoreService
    {
        private readonly IRepository<Store> _storeRepository = new StoreCsvRepository();

        public bool AddStore(AddStoreForm form)
        {
            if (_storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber == form.StoreNumber) != null) return false;
            _storeRepository.Add(new Store(form.StoreNumber, form.StoreName, form.StoreManagerName, form.OpeningTime, form.ClosingTime));
            _storeRepository.SaveChanges();
            return true;
        }

        public StoreViewModel GetStore(int storeNumber)
        {
            return GetStores().FirstOrDefault(x => x.StoreNumber == storeNumber && !string.IsNullOrWhiteSpace(x.StoreName));
        }

        public ICollection<StoreViewModel> GetStores()
        {
            var storeViewModels = new List<StoreViewModel>();
            foreach(var store in _storeRepository.GetAll().Where(x => !string.IsNullOrWhiteSpace(x.StoreName)))
            {
                storeViewModels.Add(new StoreViewModel() { StoreNumber = store.StoreNumber.Value, StoreName = store.StoreName, StoreManagerName = store.StoreManagerName, OpeningTime = store.OpeningTime, ClosingTime = store.ClosingTime });
            }
            return storeViewModels;
        }

        public bool UpdateStore(int storeNumber, UpdateStoreForm form)
        {
            var store = _storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber == storeNumber);
            if (store == null) return false;
            store.StoreName = form.StoreName;
            store.StoreManagerName = form.StoreManagerName;
            store.OpeningTime = form.OpeningTime;
            store.ClosingTime = form.ClosingTime;
            _storeRepository.Add(store);
            _storeRepository.SaveChanges();
            return true;
        }

        public bool DeleteStore(int storeNumber)
        {
            var store = _storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber == storeNumber);
            if (store == null) return false;
            _storeRepository.Delete(store);
            _storeRepository.SaveChanges();
            return true;
        }
    }
}