using System;

namespace StoreManagement.Models.ViewModels
{
    public class StoreViewModel
    {
        public int StoreNumber { get; set; }
        public string StoreName { get; set; }
        public string StoreManagerName { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
    }
}