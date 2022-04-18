using SalesAPI.DTO;
using SalesAPI.Helper;
using System.Threading.Tasks;

namespace SalesAPI.IRepository
{
    public interface IHRrepo
    {
        public Task<MessageHelper> Create(HRCommonDTO hRCommon);
    }
}
