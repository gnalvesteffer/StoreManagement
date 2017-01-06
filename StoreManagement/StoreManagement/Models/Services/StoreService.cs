using StoreManagement.Models.Data;
using StoreManagement.Models.Forms;
using StoreManagement.Models.Repositories;
using StoreManagement.Models.Responses;
using StoreManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Models.Services
{
    public class StoreService
    {
        private readonly IRepository<Store> _storeRepository = new StoreCsvRepository();

        public ValidationResponse AddStore(StoreForm form)
        {
            if (_storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber.HasValue && x.StoreNumber == form.StoreNumber) != null) return new ValidationResponse("A store with this number already exists.");
            try
            {
                _storeRepository.Add(form.ConvertToStore());
                _storeRepository.SaveChanges();
            }
            catch(Exception ex)
            {
                return new ValidationResponse(ex.Message);
            }
            return new ValidationResponse();
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
                if (store.StoreNumber == null || string.IsNullOrWhiteSpace(store.StoreName)) continue;
                storeViewModels.Add(new StoreViewModel()
                {
                    StoreNumber = store.StoreNumber.Value,
                    StoreName = store.StoreName.Trim(),
                    StoreManagerName = string.IsNullOrWhiteSpace(store.StoreManagerName) ? "Unknown" : store.StoreManagerName,
                    OpeningTime = store.OpeningTime.HasValue ? store.OpeningTime.Value.ToString("t") : "Unknown",
                    ClosingTime = store.ClosingTime.HasValue ? store.ClosingTime.Value.ToString("t") : "Unknown"
                });
            }
            return storeViewModels;
        }

        public ValidationResponse UpdateStore(int storeNumber, StoreForm form)
        {
            var store = _storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber == storeNumber);
            if (store == null) return new ValidationResponse("A store with this number does not exist.");
            Store formStore;
            try
            {
                formStore = form.ConvertToStore();
            }
            catch(Exception ex)
            {
                return new ValidationResponse(ex.Message);
            }
            _storeRepository.Delete(store);
            _storeRepository.Add(formStore);
            _storeRepository.SaveChanges();
            return new ValidationResponse();
        }

        public ValidationResponse DeleteStore(int storeNumber)
        {
            var store = _storeRepository.GetAll().FirstOrDefault(x => x.StoreNumber == storeNumber);
            if (store == null) return new ValidationResponse("No store with this number exists to be deleted.");
            _storeRepository.Delete(store);
            _storeRepository.SaveChanges();
            return new ValidationResponse();
        }
    }
}