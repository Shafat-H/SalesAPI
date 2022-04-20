using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Write
{
    public partial class ExpenseRegisterRow
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
