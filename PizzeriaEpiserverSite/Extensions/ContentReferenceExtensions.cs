using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.PageExtensions;
using EPiServer.Web.Routing;

namespace PizzeriaEpiserverSite.Extensions
{
    public static class ContentReferenceExtensions
    {
        public static string GetUrl(this ContentReference contentRef)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();    //dependency injection
            var pageUrl = urlResolver.GetVirtualPath(contentRef);
            return pageUrl.VirtualPath;
        }
    }
}