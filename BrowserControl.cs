using System.Windows.Forms;

namespace BrowserAddIn
{
    public partial class BrowserControl : UserControl
    {
        private static BrowserControl s_controlInstance = null;
        
        public BrowserControl()
        {
            InitializeComponent();
            s_controlInstance = this;
        }

        public void NavigateToUrl(string url)
        {
            webBrowser.Navigate(url);
        }

        public void DisplayText(string text)
        {
            webBrowser.DocumentText = text;
        }
        /// <summary>
        /// We will use a static instance of this control so that we can 
        /// navigate to a new page from the queue monitor.
        /// </summary>
        public static BrowserControl Instance
        {
            get
            {
                return s_controlInstance;
            }
        }
    }
}
