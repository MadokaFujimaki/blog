using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using EPiServer;

namespace PizzeriaEpiserverSite.Models.Blocks
{

    [ContentType(DisplayName = "SiteLogotypeBlock", GUID = "f354a235-c43d-4b2a-9208-86ce8f46d303", Description = "")]
    public class SiteLogotypeBlock : BlockData
    {
        [DefaultDragAndDropTarget]
        //[UIHint(UIHint.Image)]
        public virtual Url Url
        {
            get
            {
                var url = this.GetPropertyValue(b => b.Url);

                return url == null || url.IsEmpty()
                           ? new Url("/Static/img/d0088452_19251252.gif")
                           : url;
            }
            set
            {
                this.SetPropertyValue(b => b.Url, value);
            }
        }

        [CultureSpecific]
        public virtual string Title { get; set; }
    }
}