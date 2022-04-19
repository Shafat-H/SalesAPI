using System;

namespace SalesAPI.DTO.SalesDTO
{
    public class EditHeaderDTO
    {
        public long HeaderId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}

