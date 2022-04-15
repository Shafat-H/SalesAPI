using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface ISalesHeader
    {
        public Task<List<SalesHeaderDTO>> getAllHSales();
        public Task<SalesHeaderDTO> getHSalesById(int id);
        public Task<MessageHelper> DeleteHSales(int id);
        public Task<MessageHelper> CreateHSales(SalesHeaderDTO item);
        public Task<MessageHelper> UpdateHSales(SalesHeaderDTO item);
    }
}
