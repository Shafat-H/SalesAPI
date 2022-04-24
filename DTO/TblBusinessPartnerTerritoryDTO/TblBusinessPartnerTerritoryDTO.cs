using System;

namespace SalesAPI.DTO.TblBusinessPartnerTerritoryDTO
{
    public class TblBusinessPartnerTerritoryDTO
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
