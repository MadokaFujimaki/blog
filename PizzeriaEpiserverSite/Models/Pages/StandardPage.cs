using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "60ff5308-9d2b-4cd7-a072-ff661b8b05bd", Description = "Standard Page")]
    public class StandardPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 310)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
        Name = "Teaser",
        GroupName = SystemTabNames.Content,
        Order = 320)]
        public virtual TeaserBlock Teaser { get; set; }

    }
}