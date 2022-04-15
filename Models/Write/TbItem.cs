using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Write
{
    public partial class TbItem
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long Uomid { get; set; }
        public string Uomname { get; set; }
        public bool? IsActive { get; set; }
    }
}
