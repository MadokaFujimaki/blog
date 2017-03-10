using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "DiscussionBlock", GUID = "091cf591-2196-42a2-ac0d-113f649ccbda", Description = "")]
    public class DiscussionBlock : BlockData
    { 
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
    }
}