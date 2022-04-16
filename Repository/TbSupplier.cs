using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Repository
{
    public class TbSupplier : ISupplier
    {
        private readonly ReadDbContext rDbContext;
        private readonly WriteDbContext wDbContext;

        public TbSupplier(ReadDbContext rDbContext,WriteDbContext wDbContext)
        {
            this.rDbContext = rDbContext;
            this.wDbContext = wDbContext;
        }
        public async Task<MessageHelper> CreateSupplier(List<TbSupplierDTO> supplier)
        {
            var list = new List<Models.Write.TbSupplier>();
            
            foreach (var item in supplier)
            {
                var data=await wDbContext.TbSupplier.Where(x=>x.SupplierId==item.SupplierId && x.Phone==item.Phone).FirstOrDefaultAsync();
                if(data==null)
                {
                    var entity = new Models.Write.TbSupplier()
                    {
                        Name = item.Name,
                        Address = item.Address,
                        Phone = item.Phone
                    };
                    list.Add(entity);
                }
            }
            await wDbContext.AddRangeAsync(list);
            await wDbContext.SaveChangesAsync();

            return new MessageHelper()
            {
                statuscode = 200,
                Message = "Created Successfully"
            };
        }

        public Task<MessageHelper> DeleteSupplier(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TbSupplierDTO>> getAllSupplier()
        {
            throw new System.NotImplementedException();
        }

        public Task<TbSupplierDTO> getSupplierById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<MessageHelper> UpdateSupplier(TbSupplierDTO supplier)
        {
            throw new System.NotImplementedException();
        }
    }
}
