using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Write
{
    public partial class Header
    {
        public long HeaderId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
    }
}
