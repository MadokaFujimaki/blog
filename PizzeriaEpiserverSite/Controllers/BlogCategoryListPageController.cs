using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Business;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;

namespace PizzeriaEpiserverSite.Controllers
{
    public class BlogCategoryListPageController : PageController<BlogCategoryListPage>
    {
        public ActionResult Index(BlogCategoryListPage currentPage, string category)
        {
            var model = new BlogCategoryListViewModel(currentPage)
            {
                Categories = GetAllCategories(),
                Pages = FindPagesForCategory(category)
            };

            return View(model);
        }

        private List<SitePageData> FindPagesForCategory(string category)
        {

            return new List<SitePageData>();
        }

        private List<Category> GetAllCategories()
        {
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var root = categoryRepository.GetRoot();
            var children = root.Categories;
            return children.Select(x => x).ToList();
        }
    }
}