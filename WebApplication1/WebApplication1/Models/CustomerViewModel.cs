using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{

    public class CustomerViewModel
    {
        public decimal CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }

        public List<TransactionViewModel> RecentTransaction { get; set; }

        public CustomerViewModel()
        {
            RecentTransaction = new List<TransactionViewModel>(5);
        }
    }


}
