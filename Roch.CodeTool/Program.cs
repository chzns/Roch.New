using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Roch.CodeTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new CodeMain());
            //Application.Run(new FrmItemModel());
            //Application.Run(new MyCode());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
        }
    }
}
