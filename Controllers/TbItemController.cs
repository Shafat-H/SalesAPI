using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbItemController : ControllerBase
    {
        private readonly IItem _repository;

        public TbItemController(IItem repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("CreateItem")]
        public async Task<MessageHelper> CreateItem(TbItemDTO create)
        {
            var data =await _repository.CreateItem(create);
            return data;
        }


        [HttpPost]
        [Route("CreateMultipleItems")]
        public async Task<MessageHelper> CreateMultipleItems(List<TbItemDTO> items)
        {
            var data = await _repository.CreateMultipleItems(items);
            return data;
        }
        
    }
}
