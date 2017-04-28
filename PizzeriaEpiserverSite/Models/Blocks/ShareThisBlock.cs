using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "ShareThisBlock", GUID = "c52687d3-2cc7-4ee6-859c-33ebb8e228b7", Description = "")]
    public class ShareThisBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
    }
}