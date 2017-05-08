using EPiServer.Core;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PizzeriaEpiserverSite.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            Name = "MetaTitle",
            GroupName = "SEO",
            Order = 100)]
        public virtual string MetaTitle { get; set; }

        [Display(
        Name = "MetaKeywords",
        GroupName = "SEO",
        Order = 200)]
        public virtual string MetaKeywords { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
        Name = "MetaDescription",
        GroupName = "SEO",
        Order = 300)]
        public virtual string MetaDescription { get; set; }

        [UIHint(UIHint.MediaFile)]
        [Display(
        Name = "PageImage",
        GroupName = SystemTabNames.Content,
        Order = 100)]
        public virtual ContentReference PageImage { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
       Name = "TeaserText",
       GroupName = SystemTabNames.Content,
       Order = 200)]
        public virtual string TeaserText { get; set; }

      
    }
}