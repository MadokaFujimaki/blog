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

namespace PizzeriaEpiserverSite.Controllers
{
    public class CommentController : ApiController
    {
        //private CommentHandler _commentHandler;

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public BlogPageViewModel Get(int pageid)
        public IEnumerable<ApiComment> Get(int pageid)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var page = contentLoader.Get<BlogPage>(new ContentReference(pageid));  // get hela sidan
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            CommentHandler _commentHandler = new CommentHandler(contentRepository);


            var commentList = _commentHandler.LoadComments(page.CommentFolder);
            return commentList.Select(x => new ApiComment() {CommentatorName = x.CommentatorName, Date = x.Date, Text = x.Text});

            //var model = new BlogPageViewModel(page);
            //model.CommentList = _commentHandler.LoadComments(page.CommentFolder);
            //model.HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(page.CommentFolder);
            //model.CommentFolderIsSet = _commentHandler.CommentFolderIsSet(page.CommentFolder);





            //    .Get<MediaData>(imageContentReference)

            //CommentList = _commentHandler.LoadComments(),
            //    HasCommentPublishAccess = _commentHandler.CurrentUserHasCommentPublishAccess(currentPage.CommentFolder),
            //    CommentFolderIsSet = _commentHandler.CommentFolderIsSet(currentPage.CommentFolder)


            //var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>(pageid.ToString());
            //comments = _contentRepository.GetChildren<IContent>(contentRepository).ToList<IContent>();
            //comments = ServiceLocator.Current.GetInstance<IContentLoader>().Get<BlockData>();
            //return comments;

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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