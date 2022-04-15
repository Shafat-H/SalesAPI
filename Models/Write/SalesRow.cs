using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Write
{
    public partial class SalesRow
    {
        public long RsalesId { get; set; }
        public long HsalesId { get; set; }
        public long ItemId { get; set; }
        public long Quantity { get; set; }
        public long Value { get; set; }
    }
}
