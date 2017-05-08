using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "66aa97b1-eee5-43ed-a190-58746e0c8ddd", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
    public class ImageFile : ImageData
    {
       
                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Description",
                    Description = "Description field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Description { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
                  Name = "Alternate text",
                  Description = "Description of the image",
                  GroupName = SystemTabNames.Content,
                  Order = 1)]
        public virtual string ImageDescription { get; set; }

    }
}