using System;

namespace KaiCoreApp.Application.Dapper.ViewModels
{
    public class RevenueReportViewModel
    {
        /// <summary>
        /// ngày
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Doanh số
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// Lợi nhuận
        /// </summary>
        public decimal Profit { get; set; }
    }
}