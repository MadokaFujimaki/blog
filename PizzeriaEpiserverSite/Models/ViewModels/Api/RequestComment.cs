using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels.Api
{
    public class RequestComment
    {
        public int PageId { get; set; }
        public string Comment { get; set; }
        public string AuthorName { get; set; }
    }
}