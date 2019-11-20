using KaiCoreApp.Application.ViewModels.Common;
using System.Collections.Generic;

namespace KaiCoreApp.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();

        List<SlideViewModel> GetSlides(string groupAlias);

        SystemConfigViewModel GetSystemConfig(string code);
    }
}