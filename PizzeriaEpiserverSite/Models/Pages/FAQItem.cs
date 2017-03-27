using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "FAQItem", GUID = "b42c0a0c-ddfd-4910-af58-fdde6b8bb97f", Description = "", AvailableInEditMode = false)]
    public class FAQItem : SitePageData
    {
        [Display(
            Name = "Question",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Question { get; set; }

        [Display(
            Name = "Answer",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Answer { get; set; }
    }
}