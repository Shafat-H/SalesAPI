using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Read
{
    public partial class SalesHeader
    {
        public long HsalesId { get; set; }
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime Date { get; set; }
        public long TotalQty { get; set; }
        public long TotalValue { get; set; }
    }
}
