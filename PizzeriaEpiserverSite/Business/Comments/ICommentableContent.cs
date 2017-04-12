using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer;
using EPiServer.Core;

namespace PizzeriaEpiserverSite.Business.Comments
{
    public interface ICommentableContent
    {
        void ConfigureCommentSettings();
    }
}
