using Dapper;
using KaiCoreApp.Application.Dapper.Interface;
using KaiCoreApp.Application.Dapper.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KaiCoreApp.Application.Dapper.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IEnumerable<RevenueReportViewModel>> GetReports(string fromDate, string toDate)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var now = DateTime.Now;

                var firstDayMonth = new DateTime(now.Year, now.Month, 1);
                var lastDayMonth = firstDayMonth.AddMonths(1).AddDays(-1);

                dynamicParameters.Add("@fromDate", string.IsNullOrEmpty(fromDate) ? firstDayMonth.ToString("MM/dd/yyyy") : fromDate);
                dynamicParameters.Add("@toDate", string.IsNullOrEmpty(toDate) ? lastDayMonth.ToString("MM/dd/yyyy") : toDate);

                try
                {
                    return await conn.QueryAsync<RevenueReportViewModel>("GetRevenueDaily", dynamicParameters, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}