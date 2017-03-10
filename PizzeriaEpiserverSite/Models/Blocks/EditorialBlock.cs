using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "EditorialBlock", GUID = "84e5ebf7-e7eb-4be4-9c2e-50744c871669", Description = "")]
    public class EditorialBlock : BlockData
    {
     
                [Display(
                    Name = "MainBody",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         
    }
}