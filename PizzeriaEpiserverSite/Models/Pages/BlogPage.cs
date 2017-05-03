using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using PizzeriaEpiserverSite.Business.Comments;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "BlogPage", GUID = "642ca729-884c-4959-acfc-388b92c7b722", Description = "")]
    public class BlogPage : StandardPage, ICommentableContent
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


        #region ICommentableContent Members
        public void ConfigureCommentSettings()
        {
            if (!ContentReference.IsNullOrEmpty(this.CommentFolder))
            {
                return;
            }

            var contentRepository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
            var newCommentFolder = CommentHandler.AddNewCommentFolder(contentRepository, this);
            if (newCommentFolder == null)
            {
                return;
            }

            var editableNewsPage = this.CreateWritableClone() as BlogPage;
            editableNewsPage.CommentFolder = newCommentFolder.ContentLink;
            contentRepository.Save(editableNewsPage, EPiServer.DataAccess.SaveAction.Publish,
                EPiServer.Security.AccessLevel.Publish);
        }
        #endregion

        [Display(
     GroupName = SystemTabNames.Settings)]
        public virtual PageReference SearchPageLink { get; set; }

        [Display(
            Name = "Comment root folder",
            Description = "Content folder used as root for comments",
            GroupName = SystemTabNames.Settings
            )]
        [UIHint(UIHint.BlockFolder)]
        public virtual ContentReference CommentRoot { get; set; }
    }
}