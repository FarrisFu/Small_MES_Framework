using AntdUI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;

namespace FrmSetting
{
    public partial class FrmSetting : AntdUI.Window
    {
        public static SettingParameters settingParameters;
        string filepPth = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "SettingParameters.json");
        public FrmSetting(object parameter = null)
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(filepPth))
                {
                    File.Create(filepPth);
                }

                using (StreamReader streamReader = new StreamReader(filepPth, Encoding.UTF8))
                {
                    string value = streamReader.ReadToEnd();
                    settingParameters = JsonConvert.DeserializeObject<SettingParameters>(value);
                }
                if (settingParameters == null)
                {
                    settingParameters = new SettingParameters();
                }
                else
                {
                    input1.Text = settingParameters.setting1.Parameter1;
                    input2.Text = settingParameters.setting1.Parameter2;
                    input3.Text = settingParameters.setting1.Parameter3;
                    input4.Text = settingParameters.setting1.Parameter4;
                    input5.Text = settingParameters.setting1.Parameter5;
                    input6.Text = settingParameters.setting1.Parameter6;

                    input21.Text = settingParameters.setting2.Parameter21;
                    input22.Text = settingParameters.setting2.Parameter22;
                    input23.Text = settingParameters.setting2.Parameter23;
                }
            }
            catch (Exception ex)
            {
                LogService.Error("加载设置界面参数异常", ex);
                DialogService.Error( "错误", "加载设置界面参数异常");
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                settingParameters.setting1.Parameter1 = input1.Text;
                settingParameters.setting1.Parameter2 = input2.Text;
                settingParameters.setting1.Parameter3 = input3.Text;
                settingParameters.setting1.Parameter4 = input4.Text;
                settingParameters.setting1.Parameter5 = input5.Text;
                settingParameters.setting1.Parameter6 = input6.Text;

                settingParameters.setting2.Parameter21 = input21.Text;
                settingParameters.setting2.Parameter22 = input22.Text;
                settingParameters.setting2.Parameter23 = input23.Text;


                string json = JsonConvert.SerializeObject(settingParameters);
                File.WriteAllText(filepPth, json);
                LogService.Info("保存设置界面参数");
                DialogService.Success("保存参数成功");
            }
            catch (Exception ex)
            {
                LogService.Error("保存设置界面参数异常", ex);
                DialogService.Error("错误", "保存设置界面参数异常");
            }
        }
       
    }
}
