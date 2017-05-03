using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Business;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;

namespace PizzeriaEpiserverSite.Controllers
{
    public class BlogCateoryListPageController : PageController<BlogPage>
    {
        public ActionResult Index(BlogPage currentPage)
        {
            var model = new BlogCateoryListViewModel
            {
                category = (currentPage as ICategorizable).Category.GetCategories().FirstOrDefault()
            };

            return PartialView(model);
        }
    }
}