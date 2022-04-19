using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO;
using SalesAPI.DTO.Header;
using SalesAPI.DTO.Row;
using SalesAPI.DTO.SalesDTO;
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
        private readonly ReadDbContext rDbContext;

        public HRTable(WriteDbContext wDbContext, ReadDbContext rDbContext)
        {
            this.wDbContext = wDbContext;
            this.rDbContext = rDbContext;
        }
        public async Task<MessageHelper> Create(HRCommonDTO hRCommon)
        {
            try
            {
                var entity = new Models.Write.Header
                {
                    CustomerId = hRCommon.headerDTO.CustomerId,
                    CustomerName = hRCommon.headerDTO.CustomerName,
                    Date=DateTime.Now,
                    Address = hRCommon.headerDTO.Address,
                };
                await wDbContext.Header.AddAsync(entity);
                await wDbContext.SaveChangesAsync();

                var list = new List<Models.Write.Row>();

                foreach (var item in hRCommon.rowDTOs)
                {

                    var enti = new Models.Write.Row
                    {
                        HeaderId = entity.HeaderId,
                        ItemId = item.ItemId,
                        ItemName = item.ItemName,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Total = item.Price * item.Quantity,
                        IsActive=true

                    };
                    list.Add(enti);

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

        public async Task<GetByIdCommonDTO> getById(long id)
        {
            //var find = rDbContext.Header.Where(x=>x.HeaderId==id);


            var data = await Task.FromResult((from a in rDbContext.Header
                                              where a.HeaderId == id
                                              select new HeaderDTO
                                              {
                                                  CustomerId = a.CustomerId,
                                                  CustomerName = a.CustomerName,
                                                  Address = a.Address,
                                              }).FirstOrDefault());

            var data2 = await Task.FromResult((from a in rDbContext.Row
                                               where a.HeaderId == id
                                               select new RowDTO
                                               {
                                                   ItemId = a.ItemId,
                                                   ItemName = a.ItemName,
                                                   Price = a.Price,
                                                   Quantity = a.Quantity,
                                                   Total = a.Total,
                                                   IsActive=a.IsActive
                                                   
                                               }).ToList());

            return new GetByIdCommonDTO
            {
                headerDTO = data,
                rowDTOs = data2
            };

        }

        public async Task<MessageHelper> Edit(EditCommonDTO edit)
        {
            try
            {
                var data = await wDbContext.Header.Where(x => x.HeaderId == edit.Hedit.HeaderId).FirstOrDefaultAsync();

                if (data == null)
                {
                    throw new Exception("Id not Found");
                }
                data.CustomerName = edit.Hedit.CustomerName;
                data.Address = edit.Hedit.Address;
                

                wDbContext.Header.Add(data);
                await wDbContext.SaveChangesAsync();


                var list = new List<Models.Read.Row>();
                var list2 = new List<Models.Read.Row>();


                foreach (var item in edit.Redit)
                {
                    var data2 = await wDbContext.Row.Where(x => x.RowId == item.RowId).FirstOrDefaultAsync();
                    if (item.RowId == 0)
                    {
                        var ed = new Models.Read.Row()
                        {
                            HeaderId = data.HeaderId,
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Total = item.Price * item.Quantity,
                            IsActive=item.IsActive
                            
                        };
                        list2.Add(ed);
                    }
                    else
                    {
                        var edi = new Models.Read.Row()
                        {
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Total = item.Price * item.Quantity,
                            IsActive= item.IsActive
                        };
                        list.Add(edi);
                    }


                    var find = from a in edit.Redit
                               where a.RowId > 0
                               select a.RowId;

                    var inactive = (from a in wDbContext.Row
                                    where !find.Contains(a.RowId) && a.HeaderId == data.HeaderId
                                    select a).ToList();


                    inactive.ForEach(x => { x.IsActive = false; });
                    wDbContext.Row.UpdateRange(inactive);
                    await wDbContext.SaveChangesAsync();
                }
                if(list.Count()>0)
                {
                    wDbContext.UpdateRange(list);
                    await wDbContext.SaveChangesAsync();

                }
                if (list2.Count() > 0)
                {
                    wDbContext.AddRange(list2);
                    await wDbContext.SaveChangesAsync();
                }
                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Update successfully"
                };

            }
            catch (Exception)
            {

                throw;
            }


            throw new NotImplementedException();
        }
    }
}
