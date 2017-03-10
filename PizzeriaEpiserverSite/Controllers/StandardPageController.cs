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
    public class StandardPageController : PageControllerBase<StandardPage>
    {
    
        public ActionResult Index(StandardPage currentPage)
        {
            DefaultPageViewModel<StandardPage> model = new DefaultPageViewModel<StandardPage>(currentPage);
            return View(model);
        }
    }
}