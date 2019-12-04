using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Services
{
   public interface IViewRenderService
    {
        /// <summary>
        /// Render razor View as String
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
