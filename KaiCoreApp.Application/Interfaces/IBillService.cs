using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Data.Enums;
using KaiCoreApp.Utilities.Dtos;
using System.Collections.Generic;

namespace KaiCoreApp.Application.Interfaces
{
    public interface IBillService
    {
        void Create(BillViewModel billVm);

        void Update(BillViewModel billVm);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);

        BillViewModel GetDetail(int billId);

        BillDetailViewModel CreateDetail(BillDetailViewModel billDetailVm);

        void DeleteDetail(int productId, int billId);

        void UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        void Save();
    }
}