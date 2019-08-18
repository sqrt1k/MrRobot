using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MrRobot
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        private static Form1 form1 = null;
        private static NotifyIcon notifyIcon = null;
        [STAThread]
        static void Main()
        {
            //new Form1();
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resource1.network;
            notifyIcon.Click += notifyIcon_Click;
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = contextMenuStrip1;
            */
            Application.Run(new Form1());
        }
        private static void notifyIcon_Click(object sender, EventArgs e)
        {
            if (form1 == null || form1.IsDisposed)
                form1 = new Form1();
            if (!form1.Visible)
                form1.Show();
        }
    }
}
