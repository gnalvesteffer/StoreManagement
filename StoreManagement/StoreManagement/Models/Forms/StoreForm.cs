using StoreManagement.Models.Data;
using System;

namespace StoreManagement.Models.Forms
{
    public class StoreForm
    {
        public int? StoreNumber { get; set; }
        public string StoreName { get; set; }
        public string StoreManagerName { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }

        public Store ConvertToStore()
        {
            DateTime openingTime = new DateTime();
            DateTime closingTime = new DateTime();

            if (string.IsNullOrWhiteSpace(StoreName)) throw new Exception("Store name must be provided.");
            if (string.IsNullOrWhiteSpace(StoreManagerName)) throw new Exception("Manager name must be provided");
            if (StoreName.Contains(",")) throw new Exception("Store name cannot contain commas.");
            if (StoreManagerName.Contains(",")) throw new Exception("Manager name cannot contain commas.");
            if (string.IsNullOrWhiteSpace(OpeningTime) || !string.IsNullOrWhiteSpace(OpeningTime) && !DateTime.TryParse(OpeningTime, out openingTime)) throw new Exception("Opening time is not provided in a valid format.");
            if (string.IsNullOrWhiteSpace(ClosingTime) || !string.IsNullOrWhiteSpace(ClosingTime) && !DateTime.TryParse(ClosingTime, out closingTime)) throw new Exception("Closing time is not provided in a valid format.");

            return new Store(StoreNumber, StoreName.Trim(), StoreManagerName.Trim(), openingTime, closingTime);
        }
    }
}