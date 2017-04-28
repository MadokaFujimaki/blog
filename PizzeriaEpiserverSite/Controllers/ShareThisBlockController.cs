using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Controllers
{
    public class ShareThisBlockController : BlockController<ShareThisBlock>
    {
        public override ActionResult Index(ShareThisBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
