using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using PizzeriaEpiserverSite.Models.Blocks;
using PizzeriaEpiserverSite.Models.Pages;

namespace PizzeriaEpiserverSite.Business.Comments
{
    public class CommentHandler
    {
        private IContentRepository _contentRepository;

        public CommentHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void AddComment(ContentReference commentFolderReference, string name, string text, DateTime date)
        {
            PostedComment newCommentBlock = _contentRepository.GetDefault<PostedComment>(commentFolderReference);

            newCommentBlock.Text = text;
            newCommentBlock.Date = date;
            newCommentBlock.CommentatorName = name;
            IContent newCommentBlockInstance = newCommentBlock as IContent;
            newCommentBlockInstance.Name = name;

            _contentRepository.Save(newCommentBlockInstance, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.Publish);
           /* _contentRepository.Save(newCommentBlockInstance, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);*/ //EPiServer.Security.AccessLevel.Publish blev érror
        }

        public IEnumerable<PostedComment> LoadComments(ContentReference commentFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(commentFolderReference))
            {
                return null;
            }
            return _contentRepository.GetChildren<PostedComment>(commentFolderReference);
        }

        public static ContentFolder AddNewCommentFolder(IContentRepository contentRepository, IContent contentItemToComment)
        {
            var rootFolderReference = contentRepository.Get<StartPage>(ContentReference.StartPage).CommentRoot;

            if (ContentReference.IsNullOrEmpty(rootFolderReference))
            {
                return null;
            }

            var newCommentFolder = contentRepository.GetDefault<ContentFolder>(rootFolderReference);
            newCommentFolder.Name = contentItemToComment.Name;

            contentRepository.Save(newCommentFolder, EPiServer.DataAccess.SaveAction.Publish,
                EPiServer.Security.AccessLevel.Publish);

            return newCommentFolder;
        }

        // Check if current visitor have access right tio add a comment
        public bool CurrentUserHasCommentPublishAccess(ContentReference commentFolderReference)
        {
            if (ContentReference.IsNullOrEmpty(commentFolderReference))
            {
                return false;
            }

            IContent commentFolder = _contentRepository.Get<ContentFolder>(commentFolderReference);
            if (commentFolder == null)
            {
                return false;
            }

            return commentFolder.QueryDistinctAccess(EPiServer.Security.AccessLevel.Publish); //Check access
        }

        public bool CommentFolderIsSet(ContentReference commentFolderReference)
        {
            return !ContentReference.IsNullOrEmpty(commentFolderReference);
        }
    }
}