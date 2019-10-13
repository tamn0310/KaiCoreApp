using System;
using System.Collections.Generic;
using System.Text;

namespace KaiCoreApp.Data.Interfaces
{
    public interface IHasSortDelete
    {
        bool IsDeleted { get; set; }
    }
}
