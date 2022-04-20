using System.Collections.Generic;

namespace SalesAPI.DTO.ExpenseDTO
{
    public class CommonExpenseDTO
    {
        public ExpenseHeaderDTO ExpenseHeaderDTOs { get; set; }
        public List<ExpenseRowDTO> ExpenseRowDTOs { get; set; }
    }
}
