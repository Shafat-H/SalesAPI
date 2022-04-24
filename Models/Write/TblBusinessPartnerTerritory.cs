using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Write
{
    public partial class TblBusinessPartnerTerritory
    {
        public long IntBusinessUnitId { get; set; }
        public long IntAccountId { get; set; }
        public long IntTerritoryId { get; set; }
        public long IntBusinessPartnerId { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
