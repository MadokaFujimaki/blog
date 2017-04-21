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
    public class NewsPageController : PageControllerBase<NewsPage>
    {
        private CommentHandler _commentHandler;

        public NewsPageController(CommentHandler commentHandler)
        {
            _commentHandler = commentHandler;
        }

        [ContentOutputCache] // tells the method to cache any results from partial views
        public ActionResult Index(NewsPage currentPage)
        {
            //DefaultPageViewModel<NewsPage> model = new DefaultPageViewModel<NewsPage>(currentPage);
            var model = new NewsPageViewModel(currentPage)
            {
                CommentList = _commentHandler.LoadComments(currentPage.CommentFolder),
                HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(currentPage.CommentFolder),
                CommentFolderIsSet = _commentHandler.CommentFolderIsSet(currentPage.CommentFolder)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewsPage currentPage, string CommentatorName, string Text)
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