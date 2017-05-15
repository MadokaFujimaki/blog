using PizzeriaEpiserverSite.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.PageExtensions;
using EPiServer.Web.Routing;
using PizzeriaEpiserverSite.Business.Comments;
using PizzeriaEpiserverSite.Models.Blocks;
using PizzeriaEpiserverSite.Models.Pages;
using PizzeriaEpiserverSite.Models.ViewModels.Api;

namespace PizzeriaEpiserverSite.Controllers
{
    public class CommentController : ApiController
    {
        private readonly IContentLoader _contentLoader;
        private readonly CommentHandler _commentHandler;

        public CommentController()
        {
            _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            _commentHandler = ServiceLocator.Current.GetInstance<CommentHandler>();
        }

        // GET api/<controller>/5
        public IEnumerable<ApiComment> Get(int pageid)
        {
            var page = _contentLoader.Get<BlogPage>(new ContentReference(pageid));  // get hela sidan

            var commentList = _commentHandler.LoadComments(page.CommentFolder);
            return commentList.Select(x => new ApiComment() {CommentatorName = x.CommentatorName, Date = x.Date, Text = x.Text});

            //var model = new BlogPageViewModel(page);
            //model.CommentList = _commentHandler.LoadComments(page.CommentFolder);
            //model.HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(page.CommentFolder);
            //model.CommentFolderIsSet = _commentHandler.CommentFolderIsSet(page.CommentFolder); 
        }

        // POST api/<controller>
        [HttpPost]
        public RequestComment Post([FromBody] RequestComment comment)
        {
            var page = _contentLoader.Get<BlogPage>(new ContentReference(comment.PageId));
             _commentHandler.AddComment(page.CommentFolder, comment.AuthorName, comment.Comment, DateTime.Now);

            return comment;

            //return comment.AuthorName;
            //var page = _contentLoader.Get<BlogPage>(new ContentReference(comment.PageId));  // get hela sidan
            //_commentHandler.
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}