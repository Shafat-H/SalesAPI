using System;

namespace SalesAPI.DTO
{
    public class SalesHeaderDTO
    {
        public long HsalesId { get; set; }
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime Date { get; set; }
        public long TotalQty { get; set; }
        public long TotalValue { get; set; }
    }
}
