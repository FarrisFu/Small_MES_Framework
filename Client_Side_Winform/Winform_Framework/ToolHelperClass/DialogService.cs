using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolHelperClass
{
    public class DialogService
    {
        public static Form mainForm;
        public DialogService() { }

        public static void Success( string content, string title = "成功")
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(mainForm, title, content, AntdUI.TType.Success)
            {
                OnButtonStyle = (id, btn) =>
                {
                    btn.BackExtend = "135, #6253E1, #04BEFE";
                },
                CancelText = null,
                OkText = "OK"
            });
        }
        public static void Error(string content, string title = "错误")
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(mainForm, title, content, AntdUI.TType.Error)
            {

            });
        }

        public static void Warn(string content, string title = "警告")
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(mainForm, title, content, AntdUI.TType.Warn)
            {
                OnButtonStyle = (id, btn) =>
                {
                    btn.BackExtend = "135, #6253E1, #04BEFE";
                },
                CancelText = null,
                OkText = "OK"
            });
        }
    }
}
