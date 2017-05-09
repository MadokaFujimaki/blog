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
using PizzeriaEpiserverSite.Models.Pages;

namespace PizzeriaEpiserverSite.Controllers
{
    public class CommentController : ApiController
    {
        IEnumerable<ApiComment> comments = new List<ApiComment>() { new ApiComment() { Id = 2, Comment = "aaa", Name = "aa" } };

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public ApiComment Get(int pageid)
        {
            //var pageId = currentPage.PageLink.ID;
            var comment = comments.FirstOrDefault(x => x.Id == pageid);

            //var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>(pageid.ToString());
            //comments = _contentRepository.GetChildren<IContent>(contentRepository).ToList<IContent>();
            //comments = ServiceLocator.Current.GetInstance<IContentLoader>().Get<BlockData>();
            return comment;

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