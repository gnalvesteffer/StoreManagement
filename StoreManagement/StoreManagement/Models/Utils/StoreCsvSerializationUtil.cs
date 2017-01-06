using StoreManagement.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.Models.Utils
{
    public static class StoreCsvSerializationUtil //ToDo: make generic.
    {
        public static ICollection<Store> DeserializeStores(params string[] csvRecords)
        {
            var stores = new List<Store>();
            foreach (var record in csvRecords)
            {
                var store = new Store();
                var recordParams = record.Split(',');
                for (var paramIndex = 0; paramIndex < recordParams.Length; ++paramIndex)
                {
                    switch (paramIndex)
                    {
                        case 0: //Store Number
                            int storeNumber;
                            if (int.TryParse(recordParams[paramIndex], out storeNumber))
                            {
                                store.StoreNumber = storeNumber;
                            }
                            break;
                        case 1: //Store Name
                            store.StoreName = recordParams[paramIndex]?.Trim() ?? string.Empty;
                            break;
                        case 2: //Store Manager Name
                            store.StoreManagerName = recordParams[paramIndex]?.Trim() ?? string.Empty;
                            break;
                        case 3: //Opening Time
                            DateTime openingTime;
                            if (DateTime.TryParse(recordParams[paramIndex], out openingTime))
                            {
                                store.OpeningTime = openingTime;
                            }
                            break;
                        case 4: //Closing Time
                            DateTime closingTime;
                            if (DateTime.TryParse(recordParams[paramIndex], out closingTime))
                            {
                                store.ClosingTime = closingTime;
                            }
                            break;
                    }
                }
                stores.Add(store);
            }
            return stores;
        }

        public static string SerializeStores(params Store[] stores)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var store in stores)
            {
                sb.AppendLine($"{store.StoreNumber},{store.StoreName},{store.StoreManagerName},{(store.OpeningTime.HasValue ? store.OpeningTime.Value.ToString("hh:mmtt") : string.Empty)},{(store.ClosingTime.HasValue ? store.ClosingTime.Value.ToString("hh:mmtt") : string.Empty)}");
            }
            return sb.ToString();
        }
    }
}