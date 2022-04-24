using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO.ExpenseDTO;
using SalesAPI.IRepository;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpense repository;

        public ExpenseController(IExpense repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("getExpense")]
        public async Task<IActionResult> getExpense()
        {
            var data =await repository.getExpense();

            if(data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Route("createExpense")]
        public async Task<IActionResult> createExpense(CommonExpenseDTO create)
        {
            var data = await repository.createExpense(create);
            return Ok(data);
        }

        [HttpGet]
        [Route("getExpenseById")]
        public async Task<IActionResult> getExpenseById(long id)
        {
            var data= await repository.getExpenseById(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("deleteExpense")]
        public async Task<IActionResult> deleteExpense(long id)
        {
            var data = await repository.deleteExpense(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("updateExpense")]
        public async Task<IActionResult> updateExpense(CommonExpenseDTO edit)
        {
            var data = await repository.updateExpense(edit);
            return Ok(data);
        }

        [HttpPut]
        [Route("acceptExpense")]
        public async Task<IActionResult> acceptExpense(long id,bool isActive)
        {
            var data =  await repository.acceptExpense(id,isActive);
            return Ok(data);
        }

    }
}
