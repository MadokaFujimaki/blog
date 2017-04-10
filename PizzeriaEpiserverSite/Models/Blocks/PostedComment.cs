using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PizzeriaEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "Posted comment", GUID = "4f9e2db6-c38d-4a80-b4bd-88c73fc6b539", Description = "Used to store a posted comment", AvailableInEditMode = false)]
    public class PostedComment : BlockData
    {
        [Display(
         Name = "Date",
         Description = "Date when the comment was added",
         GroupName = SystemTabNames.Content,
         Order = 100)]
        public virtual DateTime Date { get; set; }

        [Display(
         Name = "Name",
         Description = "Name of the person making the comment",
         GroupName = SystemTabNames.Content,
         Order = 200)]
        public virtual string CommentatorName { get; set; }

        [Display(
            Name = "Text",
            Description = "The actual comment text",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string Text { get; set; }

    }
}