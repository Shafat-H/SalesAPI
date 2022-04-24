using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DTO.TblBusinessPartnerTerritoryDTO;
using SalesAPI.IRepository;
using System.Threading.Tasks;

namespace SalesAPI.Controllers
{
    
    [ApiController]
    public class BusinessPatnerTerritoryController : ControllerBase
    {
        private readonly IBusinessPatnerTerritory repository;

        public BusinessPatnerTerritoryController(IBusinessPatnerTerritory repository)
        {
            this.repository = repository;
        }

        [HttpPut]
        [Route("addTerritory")]
        public async Task<IActionResult> addTerritory(long BusinessUnitId, long territoryid)
        {
            var data =await repository.addTerritory(BusinessUnitId, territoryid);
            return Ok(data);
        }

        [HttpPost]
        [Route("addPatner")]
        public async Task<IActionResult> addPatner(TblBusinessPartnerTerritoryDTO create)
        {
            var data= await repository.addPatner(create);
            return Ok(data);

        }

        [HttpPut]
        [Route("inactive")]
        public async Task<IActionResult> inactive(long BusinessUnitId, bool IsActive)
        {
            var data =await repository.inActive(BusinessUnitId, IsActive);
            return Ok(data);
        }
    }
}
