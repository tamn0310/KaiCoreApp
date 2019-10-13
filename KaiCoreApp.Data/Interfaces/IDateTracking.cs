using System;
using System.Collections.Generic;
using System.Text;

namespace KaiCoreApp.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime CreatedDate { get; set; }
        DateTime DateModified { get; set; }
    }
}
