using System;

namespace StoreManagement.Models.ViewModels
{
    public class StoreViewModel
    {
        public int StoreNumber { get; set; }
        public string StoreName { get; set; }
        public string StoreManagerName { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }
    }
}