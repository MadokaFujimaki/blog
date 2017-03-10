using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlock", GUID = "f46701e6-e896-4b67-a6bc-aad687e629aa", Description = "")]
    public class TeaserBlock : BlockData
    {
        [UIHint(UIHint.Image)]
        [Display(
                 Name = "TeaserImage",
                 GroupName = SystemTabNames.Content,
                 Order = 100)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(
         Name = "TeaserHeading",
         GroupName = SystemTabNames.Content,
         Order = 200)]
        public virtual string TeaserHeading { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
         Name = "TeaserText",
         GroupName = SystemTabNames.Content,
         Order = 300)]
        public virtual string TeaserText { get; set; }


        [Display(
         Name = "TeaserLink",
         GroupName = SystemTabNames.Content,
         Order = 400)]
        public virtual PageReference TeaserLink { get; set; }
    }
}