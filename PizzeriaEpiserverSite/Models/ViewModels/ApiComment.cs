using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzeriaEpiserverSite.Models.ViewModels
{
    public class ApiComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
    }
}