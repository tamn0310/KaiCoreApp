using System;
using System.Collections.Generic;
using System.Text;

namespace KaiCoreApp.Infrastructure.Interfaces
{
  public  interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
