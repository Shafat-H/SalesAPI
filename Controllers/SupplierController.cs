using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier repository;

        public SupplierController(ISupplier repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("CreateSupplier")]
        public async Task<MessageHelper> CreateSupplier(List<TbSupplierDTO> create)
        {
            var data =await repository.CreateSupplier(create);
            return data;
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<MessageHelper> UpdateSupplier(TbSupplierDTO edit)
        {
            var data =await repository.UpdateSupplier(edit);
            return data;
        }

        [HttpGet]
        [Route("getAllSupplier")]
        public async Task<IActionResult> getAllSupplier()
        {
            var data =await repository.getAllSupplier();
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("getSupplierById")]
        public async Task<IActionResult> getSupplierById(long id)
        {
            var data = await repository.getSupplierById(id);
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("")]
        public async Task<MessageHelper> delete(long id)
        {
            var data = await repository.DeleteSupplier(id);
            return data;
        }
    }
}
