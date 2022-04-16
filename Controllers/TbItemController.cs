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


        [HttpGet]
        [Route("getAllItem")]
        public async Task<IActionResult> getAllItem()
        {
            var data =await _repository.getAllItem();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet]
        [Route("getItemById/{id}")]
        public async Task<IActionResult> getItemById(long id)
        {
            var data = await _repository.getItemById(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateItem")]
        public async Task<MessageHelper> UpdateItem(TbItemUpdateDTO update)
        {
            var data = await _repository.UpdateItem(update);
            
            return data;
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<MessageHelper> DeleteItem(long id)
        {
            var data = await _repository.DeleteItem(id);
            return data;
        }

        
    }
}
