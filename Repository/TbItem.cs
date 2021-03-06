using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Repository
{
    public class TbItem : IItem
    {
        private readonly ReadDbContext rDbContext;
        private readonly WriteDbContext wDbContext;

        public TbItem(ReadDbContext rDbContext, WriteDbContext wDbContext)
        {
            this.rDbContext = rDbContext;
            this.wDbContext = wDbContext;
        }

        ////.......Create New Item.........
        public async Task<MessageHelper> CreateItem(TbItemDTO item)
        {
            try
            {
                var data = rDbContext.TbItem.Where(x => x.ItemId == item.ItemId).FirstOrDefault();

                if (data != null)
                {
                    throw new Exception("Item Already Created");
                }
                var entity = new Models.Write.TbItem
                {
                    ItemName = item.ItemName,
                    Uomid = item.Uomid,
                    Uomname = item.Uomname,
                    IsActive = true
                };
                await wDbContext.TbItem.AddAsync(entity);
                await wDbContext.SaveChangesAsync();
                return new MessageHelper()
                {
                    statuscode = 200,
                    Message = "Created Successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<MessageHelper> DeleteItem(long id)
        {
            try
            {
                var find = await wDbContext.TbItem.FindAsync(id);
                if (find == null)
                {
                    throw new Exception("Item Not Found");
                }
                wDbContext.TbItem.Remove(find);
                await wDbContext.SaveChangesAsync();

                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Delete Successfully"
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<List<TbItemDTO>> getAllItem()
        {
            try
            {
                var data = await Task.FromResult((from a in rDbContext.TbItem
                                                  where a.IsActive == true
                                                  select new TbItemDTO
                                                  {
                                                      ItemId = a.ItemId,
                                                      ItemName = a.ItemName,
                                                      Uomid = a.Uomid,
                                                      Uomname = a.Uomname

                                                  }).ToList());
                return data;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Task<TbItemDTO> getItemById(long id)
        {
            try
            {
                var data = Task.FromResult((from a in rDbContext.TbItem
                                            where a.IsActive == true && a.ItemId == id
                                            select new TbItemDTO
                                            {
                                                ItemId = a.ItemId,
                                                ItemName = a.ItemName,
                                                Uomid = a.Uomid,
                                                Uomname = a.Uomname
                                            }).FirstOrDefault());
                if(data == null)
                {
                    throw new Exception("Item Not Found");
                }
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreateMultipleItems(List<TbItemDTO> create)
        {
            try
            {
                var list = new List<Models.Write.TbItem>();

                foreach (var itm in create)
                {
                    var entity = new Models.Write.TbItem
                    {
                        ItemName = itm.ItemName,
                        Uomid = itm.Uomid,
                        Uomname = itm.Uomname,
                        IsActive = true
                    };
                    list.Add(entity);

                }

                await wDbContext.TbItem.AddRangeAsync(list);
                await wDbContext.SaveChangesAsync();


                return new MessageHelper()
                {
                    statuscode = 200,
                    Message = "Created Successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<MessageHelper> UpdateItem(TbItemUpdateDTO update)
        {
            try
            {
                var data =await wDbContext.TbItem.Where(x => x.ItemId == update.ItemId).FirstOrDefaultAsync();
                if (data == null)
                {
                    throw new Exception("Item Not Found");
                }
                data.ItemName = update.ItemName;
                data.Uomid = update.Uomid;
                data.Uomname = update.Uomname;
                data.IsActive = update.IsActive;


                wDbContext.TbItem.Update(data);
                await wDbContext.SaveChangesAsync();

                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Successfully Update"
                };
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

}
