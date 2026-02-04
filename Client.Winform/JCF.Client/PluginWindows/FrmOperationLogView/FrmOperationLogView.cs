using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass.HttpService;

namespace FrmOperationLogView
{
    public partial class FrmOperationLogView : AntdUI.Window
    {
        public FrmOperationLogView(object parameter = null)
        {
            InitializeComponent();
        }

        private async void FrmOperationLogView_Load(object sender, EventArgs e)
        {
            var result = await OperationLogService.GetOperationLogs();
            tabOperationLog.DataSource = result.Data;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var result=await OperationLogService.GetOperationLogs();
            tabOperationLog.DataSource= result.Data;
        }

       
    }
}
