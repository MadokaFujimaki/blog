using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Business.Comments;
using PizzeriaEpiserverSite.Models.Blocks;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;

namespace PizzeriaEpiserverSite.Controllers
{
    public class BlogPageController : PageControllerBase<BlogPage>
    {
        private CommentHandler _commentHandler;

        public BlogPageController(CommentHandler commentHandler)
        {
            _commentHandler = commentHandler;
        }

        [ContentOutputCache] // tells the method to cache any results from partial views
        public ActionResult Index(BlogPage currentPage)
        {
            //DefaultPageViewModel<BlogPage> model = new DefaultPageViewModel<BlogPage>(currentPage);
            var model = new BlogPageViewModel(currentPage)
            {
                CommentList = _commentHandler.LoadComments(currentPage.CommentFolder),
                HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(currentPage.CommentFolder),
                CommentFolderIsSet = _commentHandler.CommentFolderIsSet(currentPage.CommentFolder)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BlogPage currentPage, string CommentatorName, string Text)
        {
            _commentHandler.AddComment(currentPage.CommentFolder, CommentatorName, Text, DateTime.Now);   //save the comment

            return RedirectToAction("Index");
        }

        public ActionResult ReportComment(ContentReference commentReference)
        {
            _commentHandler.ReportComment(commentReference);
            return RedirectToAction("Index");
        }
    }
}