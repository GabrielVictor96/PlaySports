using System.Collections.Generic;
using X.PagedList.Mvc.Common;

namespace PlaySports.UI.MvcCore.Utils
{
    public class XPagedListOptions
    {
        public static PagedListRenderOptions GetRenderOptions()
        {
            return new PagedListRenderOptions
            {
                LinkToFirstPageFormat = "<i class='far fa-chevron-double-left'></i>",
                LinkToPreviousPageFormat = "<i class='fas fa-chevron-left'></i>",
                LinkToNextPageFormat = "<i class='fas fa-chevron-right'></i>",
                LinkToLastPageFormat = "<i class='far fa-chevron-double-right'></i>",
                DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
                DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
                Display = PagedListDisplayMode.IfNeeded,
                UlElementClasses = new List<string> { "pagination", "justify-content-center" },
                LiElementClasses = new List<string> { "page-item" },
                PageClasses = new List<string> { "page-link" }
            };
        }
    }
}