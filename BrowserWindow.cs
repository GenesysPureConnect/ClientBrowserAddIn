using ININ.InteractionClient.AddIn;

namespace BrowserAddIn
{
    public class BrowserWindow : AddInWindow
    {
        private BrowserControl _content;

        public BrowserWindow()
        {
            _content = new BrowserControl();
        }

        /// <summary>
        /// The friendly name of the category. This is displayed 
        /// in the Client Pages dialog. 
        /// </summary>
        protected override string CategoryDisplayName
        {
            get { return "Custom AddIn Windows"; }
        }

        /// <summary>
        /// The unique identifier of the window’s category. If you are adding         /// multiple custom windows and want them to appear in the same category,         /// this value must match for each window. 
        /// </summary>
        protected override string CategoryId
        {
            get { return "Custom AddIn Windows"; }
        }

        /// <summary>
        /// The user control or custom control to embed (docked to fill) inside the
        /// window when the window is created
        /// </summary>
        public override object Content
        {
            get 
            {
                return _content;
            }
        }

        /// <summary>
        /// The friendly name of the window. This is displayed in the Client Pages 
        /// dialog when the user is selecting which pages to display in the client.
        /// </summary>
        protected override string DisplayName
        {
            get { return "Browser Tab"; }
        }

        /// <summary>
        /// The unique identifier of this window. This is used, for example, when the         /// Interaction Client persists the open “windows” (tabs) during shutdown and         /// re-creates each window on startup.         /// </summary>
        protected override string Id
        {
            get { return "Browser Tab"; }
        }
    }
}
