namespace SalesAPI.DTO
{
    public class TbItemDTO
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long Uomid { get; set; }
        public string Uomname { get; set; }
        public bool IsActive { get; set; }

    }
}
