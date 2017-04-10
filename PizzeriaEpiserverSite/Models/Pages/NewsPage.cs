using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "642ca729-884c-4959-acfc-388b92c7b722", Description = "")]
    public class NewsPage : StandardPage
    {
        [Display(
            Name = "MainListing",
            Description = "A listing of news pages",
            GroupName = SystemTabNames.Content,
            Order = 315)]
        public virtual ListingBlock MainListing { get; set; }

        [Display(
          Name = "Comment folder",
          Description = "Folder used as root for comments. If not set, comment function will be disabled",
          GroupName = SystemTabNames.Content,
          Order = 500)]
        [UIHint(UIHint.BlockFolder)]
        public virtual ContentReference CommentFolder { get; set; }


    }
}