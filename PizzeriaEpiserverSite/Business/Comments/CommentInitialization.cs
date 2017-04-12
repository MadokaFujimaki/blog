using System;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace PizzeriaEpiserverSite.Business.Comments
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CommentInitialization : IInitializableModule
    {
        private bool _eventsAttacked = false; // only add the listener if the flag is not set
        public void Initialize(InitializationEngine context)
        {
            if (!_eventsAttacked)
            {
                //Add initialization logic, this method is called once after CMS has been initialized
                ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent += new EventHandler<ContentEventArgs>(PublishingCommentableContent);
                _eventsAttacked = true;
            }
        }
        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
            ServiceLocator.Current.GetInstance<IContentEvents>().PublishingContent -= new EventHandler<ContentEventArgs>(PublishingCommentableContent);
        }

        public static void PublishingCommentableContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as ICommentableContent;
            if (content == null)
            {
                return;
            }
            content.ConfigureCommentSettings();
        }
    }
}