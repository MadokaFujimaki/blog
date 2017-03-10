using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;

namespace PizzeriaEpiserverSite.Controllers
{
    public class ForumPageController : PartialContentController<ForumPage>
    {
        public ActionResult Index(ForumPage currentPage)
        {
            DefaultPageViewModel<ForumPage> model = new DefaultPageViewModel<ForumPage>(currentPage);
            return View(model);
        }

    }
}