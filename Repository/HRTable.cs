using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using SalesAPI.Models.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Repository
{
    public class HRTable : IHRrepo
    {
        private readonly WriteDbContext wDbContext;

        public HRTable(WriteDbContext wDbContext)
        {
            this.wDbContext = wDbContext;
        }
        public async Task<MessageHelper> Create(HRCommonDTO hRCommon)
        {
            try
            {
                var entity = new Models.Write.Header
                {
                    CustomerId = hRCommon.headerDTO.CustomerId,
                    CustomerName = hRCommon.headerDTO.CustomerName,
                    Address = hRCommon.headerDTO.Address,
                    Date = hRCommon.headerDTO.Date,
                };
                await wDbContext.Header.AddAsync(entity);
                await wDbContext.SaveChangesAsync();

                var list = new List<Models.Write.Row>();
                
                foreach(var item in hRCommon.rowDTOs)
                {
                    var da =await wDbContext.Row.Where(x => x.ItemId ==item.ItemId && x.HeaderId==item.HeaderId ).FirstOrDefaultAsync();
                    if(da==null)
                    {
                        var enti = new Models.Write.Row
                        {
                            HeaderId = entity.HeaderId,
                            ItemId=item.ItemId,
                            ItemName = item.ItemName,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Total = item.Price * item.Quantity,

                        };
                        list.Add(enti);
                    }
                }
                await wDbContext.Row.AddRangeAsync(list);
                await wDbContext.SaveChangesAsync();


                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Create Successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
