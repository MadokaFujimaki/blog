using EPiServer.Core;
using PizzeriaEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class BlockEditPageViewModel : IPageViewModel<SitePageData>
    {
        public PreviewBlock previewBlock { get; set; }
        public SitePageData CurrentPage { get; set; }

        public BlockEditPageViewModel (PageData page , IContent content)
        {
            previewBlock = new PreviewBlock(page, content);
            CurrentPage = page as SitePageData;

        }

    }
}