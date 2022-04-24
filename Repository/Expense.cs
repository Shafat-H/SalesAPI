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

                var totalRequestA = create.ExpenseRowDTOs.Sum(x => x.RequestAmount);

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
                var data = await wDbContext.ExpenseRegisterHeader.Where(x => x.ExpenseRegId == id).FirstOrDefaultAsync();

                if (data == null)
                {
                    throw new Exception("Invalid Expense");
                }
                wDbContext.ExpenseRegisterHeader.Remove(data);
                await wDbContext.SaveChangesAsync();

                var data2 = await wDbContext.ExpenseRegisterRow.Where(x => x.ExpenseRegId == data.ExpenseRegId).ToListAsync();
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
                                                      Attachment = a.Attachment,
                                                      TotalRequestAmount = a.TotalRequestAmount,
                                                      TotalApproveAmount = a.TotalApproveAmount,
                                                      PaymentVoucherId = a.PaymentVoucherId,
                                                      PaymentVoucherCode = a.PaymentVoucherCode,
                                                      TypeId = a.TypeId,
                                                      TypeName = a.TypeName

                                                  }).FirstOrDefault());
                var data2 = await Task.FromResult((from a in wDbContext.ExpenseRegisterRow
                                                   where a.ExpenseRegId == id & a.IsActive == true
                                                   select new ExpenseRowDTO
                                                   {
                                                       RowId = a.RowId,
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

        public async Task<MessageHelper> updateExpense(CommonExpenseDTO update)
        {


            try
            {
                var data = await wDbContext.ExpenseRegisterHeader.Where(x => x.ExpenseRegId == update.ExpenseHeaderDTOs.ExpenseRegId).FirstOrDefaultAsync();

                if (data == null)
                {
                    throw new Exception("Expense Not Found");
                }
                var totalRequestA = update.ExpenseRowDTOs.Sum(x => x.RequestAmount);

                var totalAprove = update.ExpenseRowDTOs.Sum(x => x.ApproveAmount);

                data.ExpenseRegCode = update.ExpenseHeaderDTOs.ExpenseRegCode;
                data.BranchId = update.ExpenseHeaderDTOs.BranchId;
                data.OfficeId = update.ExpenseHeaderDTOs.OfficeId;
                data.PartnerOrPayeeId = update.ExpenseHeaderDTOs.PartnerOrPayeeId;
                data.IsPartner = update.ExpenseHeaderDTOs.IsPartner;
                data.ChartOfAccountId = update.ExpenseHeaderDTOs.ChartOfAccountId;
                data.Description = update.ExpenseHeaderDTOs.Description;
                data.IsApprove = update.ExpenseHeaderDTOs.IsApprove;
                data.ApproveById = update.ExpenseHeaderDTOs.ApproveById;
                data.ApproveDate = update.ExpenseHeaderDTOs.ApproveDate;
                data.ActionBy = update.ExpenseHeaderDTOs.ActionBy;
                data.IsActive = update.ExpenseHeaderDTOs.IsActive;
                data.LastActionDateTime = DateTime.Now;
                data.Attachment = update.ExpenseHeaderDTOs.Attachment;
                data.TotalRequestAmount = totalRequestA;
                data.TotalApproveAmount = totalAprove;
                data.PaymentVoucherId = update.ExpenseHeaderDTOs.PaymentVoucherId;
                data.PaymentVoucherCode = update.ExpenseHeaderDTOs.PaymentVoucherCode;
                data.TypeId = update.ExpenseHeaderDTOs.TypeId;
                data.TypeName = update.ExpenseHeaderDTOs.TypeName;


                wDbContext.ExpenseRegisterHeader.Update(data);
                await wDbContext.SaveChangesAsync();

                var list1 = new List<Models.Write.ExpenseRegisterRow>();
                var list2 = new List<Models.Write.ExpenseRegisterRow>();

                foreach (var item in update.ExpenseRowDTOs)
                {
                    if (item.RowId == 0)
                    {
                        var entity = new Models.Write.ExpenseRegisterRow()
                        {
                            ExpenseRegId = data.ExpenseRegId,
                            ExpenseDate = DateTime.Now,
                            Purpose = item.Purpose,
                            RequestAmount = item.RequestAmount,
                            ApproveAmount = 0,
                            IsActive = true,
                            LastActionDateTime = item.LastActionDateTime,
                            ChartOfAccountId = item.ChartOfAccountId,

                        };
                        list1.Add(entity);
                    }
                    else
                    {
                        var entity = new Models.Write.ExpenseRegisterRow()
                        {
                            RowId = item.RowId,
                            ExpenseRegId = data.ExpenseRegId,
                            ExpenseDate = DateTime.Now,
                            Purpose = item.Purpose,
                            RequestAmount = item.RequestAmount,
                            ApproveAmount = item.ApproveAmount,
                            IsActive = item.IsActive,
                            LastActionDateTime = item.LastActionDateTime,
                            ChartOfAccountId = item.ChartOfAccountId,

                        };
                        list2.Add(entity);
                    }
                }

                var find = from a in update.ExpenseRowDTOs
                           where a.ExpenseRegId > 0
                           select a.RowId;


                var ignore = (from a in wDbContext.ExpenseRegisterRow
                              where !find.Contains(a.RowId) && a.ExpenseRegId == data.ExpenseRegId
                              select a).ToList();

                wDbContext.ExpenseRegisterRow.RemoveRange(ignore);
                await wDbContext.SaveChangesAsync();


                if (list1.Count() > 0)
                {
                    await wDbContext.ExpenseRegisterRow.AddRangeAsync(list1);
                    await wDbContext.SaveChangesAsync();
                }
                if (list2.Count() > 0)
                {
                    wDbContext.ExpenseRegisterRow.UpdateRange(list2);
                    await wDbContext.SaveChangesAsync();
                }


                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Update Successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<MessageHelper> acceptExpense(long id, bool Isapprove)
        {
            try
            {
                var data = await wDbContext.ExpenseRegisterHeader.Where(x => x.ExpenseRegId == id).FirstOrDefaultAsync();

                var data2 = await wDbContext.ExpenseRegisterRow.Where(x => x.ExpenseRegId == data.ExpenseRegId).ToListAsync();
                if (data == null)
                {
                    throw new Exception("Not Found");
                }

                if (Isapprove == true)
                {
                    var total = data2.Sum(x => x.RequestAmount);

                    data.IsApprove = Isapprove;
                    data.TotalApproveAmount = total;

                    wDbContext.ExpenseRegisterHeader.Update(data);
                    await wDbContext.SaveChangesAsync();

                    var newlist = new List<decimal>();
                    foreach (var item in data2)
                    {
                        item.ApproveAmount = item.RequestAmount;
                        
                        wDbContext.ExpenseRegisterRow.Update(item);
                        await wDbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    data.IsApprove = false;

                    wDbContext.ExpenseRegisterHeader.Update(data);
                    await wDbContext.SaveChangesAsync();
                }



                //..............Message..............//
                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Update Successfully"
                };
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
