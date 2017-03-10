using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "PizzaBlock", GUID = "2806a5d2-cba5-4192-8a0e-a08373043542", Description = "")]
    public class PizzaBlock : BlockData
    {

        [Display(
            Name = "Image",
            Description = "Add an image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual Url Image { get; set; }

        [CultureSpecific]
        [Display(
        Name = "Name",
        Description = "Enter a name for the blöck",
        GroupName = SystemTabNames.Content,
        Order = 2)]
        [Required]
        public virtual string Name { get; set; }

        [Display(
        Name = "Description",
        Description = "Enter a description for the blöck",
        GroupName = SystemTabNames.Content,
        Order = 3)]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "Price",
                        Description = "Enter price for the block",
            Order = 4)]
        public virtual int Price { get; set; }


        [Display(
            Name = "Button label",
                        Description = "Enter a label for the button",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual string Button { get; set; }

        [Display(
            Name = "Url",
            Description = "Enter a Url for the button",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual Url Url { get; set; }

    }
}