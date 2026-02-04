using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Framework
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());
            //Application.Run(new FrmMain());

            // 显示登录窗口
            using (Login loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK) // 登录成功
                {
                    // 显示主窗口
                    Application.Run(new FrmMain());
                }
            }
        }
    }
}
