namespace SalesAPI.DTO.SalesDTO
{
    public class EditRowDTO
    {
        public long RowId { get; set; }
        public long HeaderId { get; set; }
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
