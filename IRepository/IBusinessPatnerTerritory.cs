using SalesAPI.DTO.TblBusinessPartnerTerritoryDTO;
using SalesAPI.Helper;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface IBusinessPatnerTerritory
    {
        public Task<MessageHelper> addTerritory(long BusinessUnitId, long territoryId);

        public Task<MessageHelper> addPatner(TblBusinessPartnerTerritoryDTO create);


        public Task<MessageHelper> inActive(long BusinessUnitId, bool IsActive);
    }
}
