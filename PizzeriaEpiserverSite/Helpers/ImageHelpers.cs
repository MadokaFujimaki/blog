using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using PizzeriaEpiserverSite.Models.Media;
using PizzeriaEpiserverSite.Models.Pages;

namespace PizzeriaEpiserverSite.Helpers
{
    public static class ImageHelpers
    {
        public static IHtmlString ImageAltText(this HtmlHelper helper,  ContentReference imageContentReference)
        {
                var currentContent = !ContentReference.IsNullOrEmpty(imageContentReference)
                                        ? ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>().Get<MediaData>(imageContentReference)
                                        : null;

            if (currentContent is ImageFile) // Images should be rendered with an image tag and an alt text
            {
                var image = currentContent as ImageFile;
                return new MvcHtmlString(image.ImageDescription);
            }
            else
            {
                return new MvcHtmlString("");
            }
        }
    }
}
