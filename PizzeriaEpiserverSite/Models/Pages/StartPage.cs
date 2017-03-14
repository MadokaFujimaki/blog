using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "770efc92-b99b-4b92-80c4-80a4a82bda52", Description = "")]
    public class StartPage : SitePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Category1",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString Category1 { get; set; }

        [Display(
        GroupName = SystemTabNames.Content,
        Order = 2)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(
       Name = "Category2",
       Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
       GroupName = SystemTabNames.Content,
       Order = 3)]
        public virtual XhtmlString Category2 { get; set; }

        [Display(
        GroupName = SystemTabNames.Content,
        Order = 320)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea2 { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Category3",
        Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
        GroupName = SystemTabNames.Content,
        Order = 3)]
        public virtual XhtmlString Category3 { get; set; }

        [Display(
        GroupName = SystemTabNames.Content,
        Order = 320)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea3 { get; set; }

        [Display(
        GroupName = SystemTabNames.Settings)]
        public virtual PageReference SearchPageLink { get; set; }

    }
}