using System.ComponentModel;

namespace KaiCoreApp.Data.Enums
{
    public enum BillStatus
    {
        [Description("Đơn hàng mới")]
        New,
        [Description("Trong tiến trình")]
        InProgress,
        [Description("Trả lại")]
        Returned,
        [Description("Đã hủy")]
        Cancelled,
        [Description("Đã hoàn thành")]
        Completed
    }
}