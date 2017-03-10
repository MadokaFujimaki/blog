using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class ListingBlockModel
    {
        public string Heading { get; set; }
        public IEnumerable<PageData> Items { get; set; }
    }
}