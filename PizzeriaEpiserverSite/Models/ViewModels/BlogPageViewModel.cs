using PizzeriaEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class BlogPageViewModel : IPageViewModel<BlogPage>
    {
        public BlogPage CurrentPage { get; set; }
        public IEnumerable<PostedComment> CommentList { get; set; }
        public bool HasCommentPublishAccess { get; set; }
        public bool CommentFolderIsSet { get; set; }

        public BlogPageViewModel(BlogPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}