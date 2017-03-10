using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ProductPage", GUID = "6b1ddf00-0957-40d1-931c-ee33743fb57c", Description = "Product Page")]
    public class ProductPage : StandardPage
    {

        [UIHint(UIHint.Textarea)]
        [Display(
                    Name = "UniqueSellingPoints",
                    GroupName = SystemTabNames.Content,
                    Order = 305)]
        public virtual string UniqueSellingPoints { get; set; }

        [Display(
            Name = "MainContentArea",
            GroupName = SystemTabNames.Content,
            Order = 320)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Name = "RelatedContentArea",
            GroupName = SystemTabNames.Content,
            Order = 330)]
        public virtual ContentArea RelatedContentArea { get; set; }

    }
}