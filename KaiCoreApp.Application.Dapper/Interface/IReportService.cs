using KaiCoreApp.Application.Dapper.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaiCoreApp.Application.Dapper.Interface
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReports(string fromDate, string toDate);
    }
}