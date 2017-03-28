using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.Core;
using EPiServer.Shell.ViewComposition;
using EPiServer.SpecializedProperties;
using System.Text;

namespace PizzeriaEpiserverSite.Plugins
{
    [IFrameComponent(
          Url = "~/Plugins/DebugPlugin.aspx",
          ReloadOnContextChange = true,
          PlugInAreas = EPiServer.Shell.PlugInArea.Assets,
          Title = "Property Debugger",
          Categories = "cms",
          MinHeight = 200,
          MaxHeight = 700)]
    public partial class DebugPlugin : EPiServer.Shell.WebForms.ContentWebFormsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GetTableHeader("Properties"));
            sb.Append(GetTableRowWithColspan1("<b>Name</b>", "<b>Value</b>"));
            string EmptyValuePlaceholder = "(Empty)";

            foreach (PropertyData pd in CurrentContent.Property)
            {
                if (pd.GetType() == typeof(PropertyContentArea))
                {
                    PropertyContentArea pca = pd as PropertyContentArea;
                    sb.Append(GetTableRowWithColspan2(string.Format("Content Area: '{0}", pca.Name)));

                    if (pca.IsNull)
                    {
                        sb.Append(GetTableRowWithColspan1(EmptyValuePlaceholder, string.Empty));
                    }
                    else
                    {
                        ContentArea ca = pca.Value as ContentArea;
                        foreach (ContentAreaItem cai in ca.Items)
                        {
                            IContent c = cai.GetContent();

                            sb.Append(GetTableRowWithColspan2(string.Format("Content item name: '{0}'", c.Name)));
                            sb.Append(GetTableRowWithColspan2(string.Format("Properties:")));
                            sb.Append(GetTableRowWithColspan1("<b>Name</b>", "<b>Value</b>"));

                            foreach (PropertyData p in c.Property)
                            {
                                sb.Append(GetTableRowWithColspan1(p.Name,
                                    p.Value != null ? p.Value.ToString() : EmptyValuePlaceholder));
                            }
                        }
                    }
                }
                else
                {
                    sb.Append(GetTableRowWithColspan1(pd.Name, pd.Value != null ? pd.Value.ToString() : EmptyValuePlaceholder));
                }
            }
            sb.Append(GetTableFooter());
            LitCtrl.Text = sb.ToString();
        }

        private string GetTableHeader(string headerText)
        {
            return "<table border='1' width='500'><tr><th colspan='2'>" + headerText + "</th></tr>";
        }

        private string GetTableRowWithColspan1(string firstcellText, string seconddCelltext)
        {
            return "<tr><td>" + firstcellText + "</td><td>" + seconddCelltext + "</td></tr>";
        }

        private string GetTableRowWithColspan2(string cellText)
        {
            return "<tr><td colspan='2'><B>" + cellText + "</B></td>" + "</tr>";
        }

        private string GetTableFooter()
        {
            return "</table><br/>";
        }
    }
}