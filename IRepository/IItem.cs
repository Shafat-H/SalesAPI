using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface IItem
    {
        public Task<List<TbItemDTO>> getAllItem();
        public Task<TbItemDTO> getItemById(long id);
        public Task<MessageHelper> DeleteItem(int id);
        public Task<MessageHelper> CreateMultipleItems(List<TbItemDTO> create);
        public Task<MessageHelper> CreateItem(TbItemDTO item);
        public Task<MessageHelper> UpdateItem(TbItemDTO item);
    }
}
