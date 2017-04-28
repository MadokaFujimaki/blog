using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaEpiserverSite.Models.Blocks;
using PizzeriaEpiserverSite.Models.Pages;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class StartPageViewModel : IPageViewModel<StartPage>
    {
        public StartPage CurrentPage { get; set; }
        public IEnumerable<PostedComment> CommentList { get; set; }
        public bool HasCommentPublishAccess { get; set; }
        public bool CommentFolderIsSet { get; set; }

        public StartPageViewModel(StartPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}