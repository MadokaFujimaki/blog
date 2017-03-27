using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System.Collections.Generic;


namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "FAQPage", GUID = "a4c86c31-ac81-44ed-9f7f-547bff8124ad", Description = "")]
    public class FAQPage : SitePageData
    {
        [Ignore]
        public IList<FAQItem> FAQItems { get; set; }
    }
}