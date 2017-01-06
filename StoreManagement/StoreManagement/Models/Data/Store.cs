using System;

namespace StoreManagement.Models.Data
{
    public class Store
    {
        public int? StoreNumber { get; set; }
        public string StoreName { get; set; }
        public string StoreManagerName { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }

        public Store() { }

        public Store(int? storeNumber, string storeName, string storeManagerName, DateTime? openingTime, DateTime? closingTime)
        {
            StoreNumber = storeNumber;
            StoreName = storeName;
            StoreManagerName = storeManagerName;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }
    }
}