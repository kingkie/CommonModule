using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IocpServer
{
    static class Program
    {
         private IoServer iocp = new IoServer(10, 1024);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int port = int.Parse(portStr.Text);
            iocp.Start(port);
            iocp.mainForm = this.mainForm;//承载显示窗体
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            iocp.Stop();
        }
    }
}
