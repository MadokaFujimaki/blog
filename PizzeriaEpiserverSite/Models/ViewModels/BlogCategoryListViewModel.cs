using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.DataAbstraction;
using PizzeriaEpiserverSite.Models.Pages;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class BlogCategoryListViewModel : IPageViewModel<BlogCategoryListPage>
    {
        public List<Category> Categories { get; set; }
        public List<SitePageData> Pages { get; set; }
        public BlogCategoryListPage CurrentPage { get; }
        public BlogCategoryListViewModel(BlogCategoryListPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}