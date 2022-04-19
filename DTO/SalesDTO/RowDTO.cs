namespace SalesAPI.DTO.Row
{
    public class RowDTO
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public bool IsActive { get; set; }
    }
}
