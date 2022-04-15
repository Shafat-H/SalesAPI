using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface ISupplier
    {
        public Task<List<TbSupplierDTO>> getAllSupplier();
        public Task<TbSupplierDTO> getSupplierById(int id);
        public Task<MessageHelper> DeleteSupplier(int id);
        public Task<MessageHelper> CreateSupplier(TbSupplierDTO item);
        public Task<MessageHelper> UpdateSupplier(TbSupplierDTO item);
    }
}
