using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface ISalesRow
    {
        public Task<List<SalesRowDTO>> getAllRSales();
        public Task<SalesRowDTO> getRSalesById(int id);
        public Task<MessageHelper> DeleteRSales(int id);
        public Task<MessageHelper> CreateRSales(SalesRowDTO item);
        public Task<MessageHelper> UpdateRSales(SalesRowDTO item);
    }
}
