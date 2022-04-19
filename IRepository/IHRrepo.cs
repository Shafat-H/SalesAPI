using SalesAPI.DTO;
using SalesAPI.DTO.SalesDTO;
using SalesAPI.Helper;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface IHRrepo
    {
        public Task<MessageHelper> Create(HRCommonDTO hRCommon);

        public Task<GetByIdCommonDTO> getById(long id);

        public Task<MessageHelper> Edit(EditCommonDTO edit);
    }
}
