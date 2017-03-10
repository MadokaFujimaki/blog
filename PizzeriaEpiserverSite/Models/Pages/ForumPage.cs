using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ForumPage", GUID = "b398c157-9faf-480e-acde-ff22cb3ddd65", Description = "")]
    public class ForumPage : StandardPage
    {
        [UIHint(UIHint.Textarea)]
        [Display(
                    Name = "UniqueSellingPoints",
                    GroupName = SystemTabNames.Content,
                    Order = 200)]
        public virtual string Description { get; set; }

        //[Display(
        //GroupName = SystemTabNames.Content,
        //Order = 210)]
        //[CultureSpecific]
        //public virtual ContentArea MainContentArea { get; set; }
    }
}