using KaiCoreApp.Application.ViewModels.Common;
using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Data.Enums;
using KaiCoreApp.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaiCoreApp.Web.Models
{
    public class CheckoutViewModel : BillViewModel
    {
        public List<ShoppingCartViewModel> Carts { get; set; }

        public List<EnumModel> PaymentMethods
        {
            get
            {
                return ((PaymentMethod[])Enum.GetValues(typeof(PaymentMethod)))
                    .Select(c => new EnumModel
                    {
                        Value = (int)c,
                        Name = c.GetDescription()
                    }).ToList();
            }
        }
    }
}