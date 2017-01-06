using System;

namespace StoreManagement.Models.Forms
{
    public class UpdateStoreForm
    {
        public string StoreName { get; set; }
        public string StoreManagerName { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}