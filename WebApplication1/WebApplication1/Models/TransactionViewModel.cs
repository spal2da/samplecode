using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    
    public class TransactionViewModel
    {
        public decimal TransactionID { get; set; }

        public DateTime? TransactionDateTime { get; set; }

        public decimal? Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
    
}
