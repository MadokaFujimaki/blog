using PizzeriaEpiserverSite.Business;
using PizzeriaEpiserverSite.Models.ViewModels;
using EPiServer.Core;
using PizzeriaEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class DefaultPageViewModel<T> : IPageViewModel<T> where T: SitePageData
    {
        public T CurrentPage { get; set; }

       public IContent Section { get; set; }

       public LayoutModel Layout { get; set; }

        public DefaultPageViewModel( T currentPage)
        {
            CurrentPage = currentPage;
            Section = ContentExtensions.GetSection(currentPage.ContentLink);
        }



    }
}