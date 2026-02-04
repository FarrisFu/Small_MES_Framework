using JCF.Service.HttpCore;
using JCF.Service.ModelRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;
using ToolHelperClass.HttpService;
namespace Winform_Framework
{
    public partial class Login : AntdUI.Window
    {
        public Login()
        {
            InitializeComponent();
            DialogService.mainForm = this;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.Text = "admin";
            txtPassword.Text = "123456";
        }
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtPassword.Focus();
        }

        private async void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                await LoginUser();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginUser();

        }

        private async Task LoginUser()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                DialogService.Warn("请输入用户名和密码");
                return;
            }
            btnLogin.Enabled = false;
            try
            {
                if (chkLocalModel.Checked)
                {

                }
                else
                {
                    LoginRequest user = new LoginRequest()
                    {
                        UserName = txtUserName.Text.Trim(),
                        Password = txtPassword.Text.Trim()
                    };
                    var result = await LoginService.Login(user);
                    if (result.Success)
                    {
                        JwtTokenProvider.SetToken(result.Data.Token);
                    }
                    else
                    {
                        DialogService.Warn("登录失败,请检查用户名和密码是否匹配");
                        return;
                    }

                }

                //DialogService.Success("登录成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                LogService.Error("登录异常", ex);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
