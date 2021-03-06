﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "BlogCategoryListPage", GUID = "a4007639-6aec-4429-9e93-ee2cac9f2fb8", Description = "")]
    public class BlogCategoryListPage : SitePageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */


        [Display(
            Name = "Comment root folder",
            Description = "Content folder used as root for comments",
            GroupName = SystemTabNames.Settings
            )]
        [UIHint(UIHint.BlockFolder)]
        public virtual ContentReference CommentRoot { get; set; }
    }
}