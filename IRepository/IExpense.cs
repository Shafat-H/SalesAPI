using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO.ExpenseDTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface IExpense
    {
        public Task<List<ExpenseHeaderDTO>> getExpense();
        public Task<CommonExpenseDTO> getExpenseById(long id);
        public Task<MessageHelper> updateExpense(CommonExpenseDTO update);
        public Task<MessageHelper> deleteExpense(long id);
        public Task<MessageHelper> createExpense(CommonExpenseDTO create);
        public Task<MessageHelper> acceptExpense(long id, bool Isapprove);
    }
}
