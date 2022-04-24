using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO.TblBusinessPartnerTerritoryDTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Repository
{
    public class BusinessPatnerTerritory : IBusinessPatnerTerritory
    {
        private readonly WriteDbContext wDbContext;

        public BusinessPatnerTerritory(WriteDbContext _wDbContext)
        {
            wDbContext = _wDbContext;
        }
        public async Task<MessageHelper> addTerritory(long BusinessUnitId, long TerritoryId)
        {
            try
            {
                var data = await wDbContext.TblBusinessPartnerTerritory.Where(x => x.IntBusinessUnitId == BusinessUnitId && x.IsActive==true).FirstOrDefaultAsync();
                if(data == null)
                {
                    throw new Exception("Account Id Not Found");
                }

                if(data.IntTerritoryId<=0)
                {
                    data.IntTerritoryId = TerritoryId; 
                    data.DteLastActionDateTime= DateTime.Now;

                    wDbContext.TblBusinessPartnerTerritory.Update(data);
                    await wDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Territory Already Exit");
                }

                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Update Succesfully"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> addPatner(TblBusinessPartnerTerritoryDTO create)
        {


            try
            {
                var data =await wDbContext.TblBusinessPartnerTerritory.Where(x => x.IntBusinessUnitId == create.IntBusinessUnitId).FirstOrDefaultAsync();

                if (data != null)
                {
                    throw new Exception("Business Partner Already Exit");
                        
                }
                var entity = new Models.Write.TblBusinessPartnerTerritory
                {
                    IntAccountId = create.IntAccountId,
                    IntTerritoryId = create.IntTerritoryId,
                    IntBusinessPartnerId=create.IntBusinessPartnerId,
                    IntActionBy = create.IntActionBy,
                    DteLastActionDateTime = DateTime.Now,
                    IsActive = true,
                };
                await wDbContext.TblBusinessPartnerTerritory.AddAsync(entity);
                await wDbContext.SaveChangesAsync();

                return new MessageHelper
                {

                    Message = "Create Successfully",
                    statuscode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<MessageHelper> inActive(long BusinessUnitId, bool IsActive)
        {
            var data =await wDbContext.TblBusinessPartnerTerritory.Where(x=>x.IntBusinessUnitId==BusinessUnitId).FirstOrDefaultAsync();

            if(data==null)
            {
                throw new Exception("Already Inactive or BusinessId Not Found");
            }

            data.IsActive = IsActive;
            wDbContext.TblBusinessPartnerTerritory.Update(data);
            await wDbContext.SaveChangesAsync();

            return new MessageHelper
            {
                statuscode=200,
                Message="Inactive Successfully"
            };

        }
    }
}
