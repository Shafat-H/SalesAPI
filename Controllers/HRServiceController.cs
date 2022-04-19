using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO;
using SalesAPI.DTO.SalesDTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [ApiController]
    public class HRServiceController : ControllerBase
    {
        private readonly IHRrepo repository;

        public HRServiceController(IHRrepo repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<MessageHelper> Create(HRCommonDTO hrCommon)
        {
            var data = await repository.Create(hrCommon);
            return data;
        }

        [HttpGet]
        [Route("getbyId")]
        public async Task<IActionResult> getbyId(long id)
        {
            var data = await repository.getById(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<MessageHelper> Edit(EditCommonDTO edit)
        {
            var data = await repository.Edit(edit);
            return data;
        }

    }
}
