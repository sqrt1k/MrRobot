using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace MrRobot
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        public void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Browser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://yandex.ru/pogoda/stavropol");
            webBrowser2.Navigate("https://news.yandex.ru/");
            webBrowser3.Navigate("https://time100.ru/");
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //richTextBox1.Text = webBrowser1.DocumentText;
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //webBrowser2.Document.Body.ScrollIntoView(true);
        }
        public void br2_scrol(bool scr, int x)
        {
            //int x = webBrowser1.Document.Body.ScrollRectangle.Top;
            if (scr)
            {
                webBrowser2.Document.Window.ScrollTo(0, x);
            }
            else
            {
                webBrowser2.Document.Window.ScrollTo(0, x);
            }
        }

    }
}
