using System;

namespace SalesAPI.DTO.ExpenseDTO
{
    public class ExpenseRowDTO
    {
        public long RowId { get; set; }
        public long ExpenseRegId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Purpose { get; set; }
        public decimal RequestAmount { get; set; }
        public decimal ApproveAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public long ChartOfAccountId { get; set; }
    }
}
