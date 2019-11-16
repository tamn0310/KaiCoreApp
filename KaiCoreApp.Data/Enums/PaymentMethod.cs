using System.ComponentModel;

namespace KaiCoreApp.Data.Enums
{
    public enum PaymentMethod
    {
        [Description("Thanh toán khi nhận hàng")]
        CashOnDelivery,
        [Description("Qua ngân hàng trực tuyến")]
        OnlinBanking,
        [Description("Qua cổng thanh toán ")]
        PaymentGateway,
        [Description("Qua thẻ Visa")]
        Visa,
        [Description("Qua Master Card")]
        MasterCard,
        [Description("Bằng PayPal")]
        PayPal,
        [Description("Bằng thẻ Atm")]
        Atm
    }
}