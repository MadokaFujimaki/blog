using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "ListingBlock", GUID = "86ee76f6-ed0f-4e6f-b73c-c265ddca39a4", Description = "")]
    public class ListingBlock : BlockData
    {
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [Display(
        Name = "RootPage",
        GroupName = SystemTabNames.Content,
        Order = 200)]
        public virtual PageReference RootPage { get; set; }
    }
}