using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRServiceController : ControllerBase
    {
        private readonly IHRrepo repository;

        public HRServiceController(IHRrepo repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public async Task<MessageHelper> create(HRCommonDTO hrCommon)
        {
            var data =await repository.Create(hrCommon);
            return data;
        }
    }
}
