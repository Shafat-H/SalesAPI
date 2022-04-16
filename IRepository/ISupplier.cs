using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface ISupplier
    {
        public Task<List<TbSupplierDTO>> getAllSupplier();
        public Task<TbSupplierDTO> getSupplierById(long id);
        public Task<MessageHelper> DeleteSupplier(long id);
        public Task<MessageHelper> CreateSupplier(List<TbSupplierDTO> supplier);
        public Task<MessageHelper> UpdateSupplier(TbSupplierDTO supplier);
    }
}
