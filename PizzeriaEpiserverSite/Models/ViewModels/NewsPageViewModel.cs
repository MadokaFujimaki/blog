using PizzeriaEpiserverSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaEpiserverSite.Models.Blocks;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class NewsPageViewModel : IPageViewModel<NewsPage>
    {
        public NewsPage CurrentPage { get; set; }
        public IEnumerable<PostedComment> CommentList { get; set; } = new List<PostedComment>();

        public NewsPageViewModel(NewsPage currentPage)
        {
            CurrentPage = currentPage;
        }
    }
}