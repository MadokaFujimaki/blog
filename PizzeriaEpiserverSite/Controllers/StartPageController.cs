using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels;
using EPiServer.Web;
using PizzeriaEpiserverSite.Business.Comments;

namespace PizzeriaEpiserverSite.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        private CommentHandler _commentHandler;

        public StartPageController(CommentHandler commentHandler)
        {
            _commentHandler = commentHandler;
        }

        [ContentOutputCache] // Sparar cashe och visar det.
        public ActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            StartPageViewModel startPage = new StartPageViewModel(currentPage)
            {
                CommentList = _commentHandler.LoadComments(currentPage.CommentFolder),
                HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(currentPage.CommentFolder),
                CommentFolderIsSet = _commentHandler.CommentFolderIsSet(currentPage.CommentFolder)
            };
            return View(startPage);
        }

        [HttpPost]
        public ActionResult Create(StartPage currentPage, string CommentatorName, string Text)
        {
            _commentHandler.AddComment(currentPage.CommentFolder,CommentatorName, Text, DateTime.Now);
            return RedirectToAction("Index");
        }

        public ActionResult ReportComment(ContentReference commenReference)
        {
            _commentHandler.ReportComment(commenReference);
            return RedirectToAction("Index");
        }

    }
}