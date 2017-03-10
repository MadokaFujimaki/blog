using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Models.Pages;



namespace PizzeriaEpiserverSite.Controllers
{
    [TemplateDescriptor(Inherited =true, Tags =new string[] {"span8"}, AvailableWithoutTag =false)]
    public class PagePartialWideController : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentContenrt)
        {     
            return PartialView("/Views/Shared/PagePartials/PagePartialWide.cshtml",currentContenrt);
        }
    }
}