using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class ApiComment
    {
        public DateTime Date { get; set; }
        public string CommentatorName { get; set; }
        public string Text { get; set; }
    }
}