using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContexts;
using SalesAPI.DTO.ExpenseDTO;
using SalesAPI.Helper;
using SalesAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Repository
{
    public class Expense : IExpense
    {
        private readonly ReadDbContext rDbContext;
        private readonly WriteDbContext wDbContext;

        public Expense(ReadDbContext rDbContext, WriteDbContext wDbContext)
        {
            this.rDbContext = rDbContext;
            this.wDbContext = wDbContext;
        }
        public async Task<MessageHelper> createExpense(CommonExpenseDTO create)
        {
            try
            {
                var data = await wDbContext.ExpenseRegisterHeader.Where(x => x.ExpenseRegId == create.ExpenseHeaderDTOs.ExpenseRegId).FirstOrDefaultAsync();

                var totalRequestA = create.ExpenseRowDTOs.Sum(x=>x.RequestAmount);

                var entity = new Models.Write.ExpenseRegisterHeader
                {
                    ExpenseRegCode = create.ExpenseHeaderDTOs.ExpenseRegCode,
                    ExpenseRegDate = DateTime.Now,
                    AccountId = create.ExpenseHeaderDTOs.AccountId,
                    BranchId = create.ExpenseHeaderDTOs.BranchId,
                    OfficeId = create.ExpenseHeaderDTOs.OfficeId,
                    PartnerOrPayeeId = create.ExpenseHeaderDTOs.PartnerOrPayeeId,
                    IsPartner = create.ExpenseHeaderDTOs.IsPartner,
                    ChartOfAccountId = create.ExpenseHeaderDTOs.ChartOfAccountId,
                    Description = create.ExpenseHeaderDTOs.Description,
                    IsApprove = create.ExpenseHeaderDTOs.IsApprove,
                    ApproveById = create.ExpenseHeaderDTOs.ApproveById,
                    ApproveDate = create.ExpenseHeaderDTOs.ApproveDate,
                    ActionBy = create.ExpenseHeaderDTOs.ActionBy,
                    IsActive = true,
                    LastActionDateTime = create.ExpenseHeaderDTOs.LastActionDateTime,
                    ServerDateTime = create.ExpenseHeaderDTOs.ServerDateTime,
                    Attachment = create.ExpenseHeaderDTOs.Attachment,
                    TotalRequestAmount = totalRequestA,
                    TotalApproveAmount = create.ExpenseHeaderDTOs.TotalApproveAmount,
                    PaymentVoucherId = create.ExpenseHeaderDTOs.PaymentVoucherId,
                    PaymentVoucherCode = create.ExpenseHeaderDTOs.PaymentVoucherCode,
                    TypeId = create.ExpenseHeaderDTOs.TypeId,
                    TypeName = create.ExpenseHeaderDTOs.TypeName
                };

                await wDbContext.ExpenseRegisterHeader.AddAsync(entity);
                await wDbContext.SaveChangesAsync();

                var List = new List<Models.Write.ExpenseRegisterRow>();


                foreach (var item in create.ExpenseRowDTOs)
                {
                    var ent = new Models.Write.ExpenseRegisterRow
                    {
                        ExpenseRegId = entity.ExpenseRegId,
                        ExpenseDate = DateTime.Now,
                        Purpose = item.Purpose,
                        RequestAmount = item.RequestAmount,
                        ApproveAmount = item.ApproveAmount,
                        IsActive = true,
                        LastActionDateTime = item.LastActionDateTime,
                        ChartOfAccountId = item.ChartOfAccountId

                    };
                    List.Add(ent);
                }
                await wDbContext.ExpenseRegisterRow.AddRangeAsync(List);
                await wDbContext.SaveChangesAsync();

                return new MessageHelper()
                {
                    statuscode = 200,
                    Message = "create successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> deleteExpense(long id)
        {
            try
            {
                var data =await wDbContext.ExpenseRegisterHeader.Where(x => x.ExpenseRegId == id).FirstOrDefaultAsync();

                if(data == null)
                {
                    throw new Exception("Invalid Expense");
                }
                wDbContext.ExpenseRegisterHeader.Remove(data);
                await wDbContext.SaveChangesAsync();

                var data2 = await wDbContext.ExpenseRegisterRow.Where(x=>x.RowId == id).ToListAsync();
                wDbContext.ExpenseRegisterRow.RemoveRange(data2);
                await wDbContext.SaveChangesAsync();


                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Delete succesfully"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ExpenseHeaderDTO>> getExpense()
        {
            try
            {
                var data = await Task.FromResult((from a in wDbContext.ExpenseRegisterHeader
                                                  where a.IsActive == true
                                                  select new ExpenseHeaderDTO
                                                  {
                                                      ExpenseRegId = a.ExpenseRegId,
                                                      ExpenseRegCode = a.ExpenseRegCode,
                                                      ExpenseRegDate = a.ExpenseRegDate,
                                                      AccountId = a.AccountId,
                                                      BranchId = a.BranchId,
                                                      OfficeId = a.OfficeId,
                                                      PartnerOrPayeeId = a.PartnerOrPayeeId,
                                                      IsPartner = a.IsPartner,
                                                      ChartOfAccountId = a.ChartOfAccountId,
                                                      Description = a.Description,
                                                      IsApprove = a.IsApprove,
                                                      ApproveById = a.ApproveById,
                                                      ApproveDate = a.ApproveDate,
                                                      ActionBy = a.ActionBy,
                                                      IsActive = a.IsActive,
                                                      LastActionDateTime = a.LastActionDateTime,
                                                      ServerDateTime = a.ServerDateTime,
                                                      Attachment = a.Attachment,
                                                      TotalRequestAmount = a.TotalRequestAmount,
                                                      TotalApproveAmount = a.TotalApproveAmount,
                                                      PaymentVoucherId = a.PaymentVoucherId,
                                                      PaymentVoucherCode = a.PaymentVoucherCode,
                                                      TypeId = a.TypeId,
                                                      TypeName = a.TypeName

                                                  }).ToList());
                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CommonExpenseDTO> getExpenseById(long id)
        {
            try
            {
                var data = await Task.FromResult((from a in wDbContext.ExpenseRegisterHeader
                                                  where a.ExpenseRegId == id && a.IsActive == true
                                                  select new ExpenseHeaderDTO
                                                  {
                                                      ExpenseRegId=a.ExpenseRegId,
                                                      ExpenseRegCode = a.ExpenseRegCode,
                                                      ExpenseRegDate = a.ExpenseRegDate,
                                                      AccountId = a.AccountId,
                                                      BranchId = a.BranchId,
                                                      OfficeId = a.OfficeId,
                                                      PartnerOrPayeeId = a.PartnerOrPayeeId,
                                                      IsPartner = a.IsPartner,
                                                      ChartOfAccountId = a.ChartOfAccountId,
                                                      Description = a.Description,
                                                      IsApprove = a.IsApprove,
                                                      ApproveById = a.ApproveById,
                                                      ApproveDate = a.ApproveDate,
                                                      ActionBy = a.ActionBy,
                                                      IsActive = a.IsActive,
                                                      LastActionDateTime = a.LastActionDateTime,
                                                      ServerDateTime = a.ServerDateTime,
                                                      Attachment = a.Attachment,
                                                      TotalRequestAmount = a.TotalRequestAmount,
                                                      TotalApproveAmount = a.TotalApproveAmount,
                                                      PaymentVoucherId = a.PaymentVoucherId,
                                                      PaymentVoucherCode = a.PaymentVoucherCode,
                                                      TypeId = a.TypeId,
                                                      TypeName = a.TypeName

                                                  }).FirstOrDefault());
                var data2 =await Task.FromResult((from a in wDbContext.ExpenseRegisterRow
                                             where a.ExpenseRegId == id & a.IsActive == true
                                             select new ExpenseRowDTO
                                             {
                                                 RowId= a.RowId,
                                                 ExpenseRegId = a.ExpenseRegId,
                                                 ExpenseDate = a.ExpenseDate,
                                                 Purpose = a.Purpose,
                                                 RequestAmount = a.RequestAmount,
                                                 ApproveAmount = a.ApproveAmount,
                                                 IsActive = a.IsActive,
                                                 LastActionDateTime = a.LastActionDateTime,
                                                 ChartOfAccountId = a.ChartOfAccountId
                                             }).ToList());

                return new CommonExpenseDTO
                {
                    ExpenseHeaderDTOs = data,
                    ExpenseRowDTOs = data2
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<MessageHelper> updateExpense(CommonExpenseDTO update)
        {
            throw new System.NotImplementedException();
        }
    }
}
