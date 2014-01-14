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
            SetButtonStates();
        }

        public void NavigateToUrl(string url)
        {
            webBrowser.Navigate(url);
        }

        public void DisplayText(string text)
        {
            webBrowser.DocumentText = text;
            SetButtonStates();
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

        private void OnWebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            SetButtonStates();
        }

        private void OnBackClick(object sender, System.EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void SetButtonStates()
        {
            btnBack.Enabled = webBrowser.CanGoBack;
            btnForward.Enabled = webBrowser.CanGoForward;
            btnReload.Visible = !webBrowser.IsBusy;
            btnStop.Visible = webBrowser.IsBusy;
        }

        private void OnForwardClick(object sender, System.EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void OnStopClick(object sender, System.EventArgs e)
        {
            webBrowser.Stop();
        }

        private void OnReloadClick(object sender, System.EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void OnUrlKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser.Navigate(txtUrl.Text);
            }
        }

        private void OnWebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtUrl.Text = webBrowser.Url.ToString();
            SetButtonStates();
        }

        private void OnWebBrowserNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            SetButtonStates();
        }
    }
}
