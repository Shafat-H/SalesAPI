using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesAPI.Models.Read
{
    public partial class ExpenseRegisterHeader
    {
        public long ExpenseRegId { get; set; }
        public string ExpenseRegCode { get; set; }
        public DateTime ExpenseRegDate { get; set; }
        public long AccountId { get; set; }
        public long BranchId { get; set; }
        public long OfficeId { get; set; }
        public long PartnerOrPayeeId { get; set; }
        public bool IsPartner { get; set; }
        public long ChartOfAccountId { get; set; }
        public string Description { get; set; }
        public bool IsApprove { get; set; }
        public long? ApproveById { get; set; }
        public DateTime? ApproveDate { get; set; }
        public long ActionBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public DateTime ServerDateTime { get; set; }
        public string Attachment { get; set; }
        public decimal TotalRequestAmount { get; set; }
        public decimal TotalApproveAmount { get; set; }
        public long PaymentVoucherId { get; set; }
        public string PaymentVoucherCode { get; set; }
        public long? TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
