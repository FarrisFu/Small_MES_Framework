using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Framework
{
    public partial class FrmMain : AntdUI.Window
    {
        Dictionary<string,List<AntdUI.MenuItem>> menuItems = new Dictionary<string, List<AntdUI.MenuItem>>();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadPage();

            //LoadLeftMenu();

        }

        private void LoadLeftMenu()
        {
            menuItems.Add("菜单1", new List<AntdUI.MenuItem>()
            {
                new AntdUI.MenuItem(){ Text="子菜单1-1"},
                new AntdUI.MenuItem(){ Text="子菜单1-2"}
            });
            menuItems.Add("菜单2", new List<AntdUI.MenuItem>()
            {
                new AntdUI.MenuItem(){ Text="子菜单2-1"},
                new AntdUI.MenuItem(){ Text="子菜单2-2"}
            });
            menuLeft.Items.Clear();
            foreach (var root in menuItems)
            {
                var rootMenu = new AntdUI.MenuItem()
                {
                    Text = "菜单1",
                    IconSvg = "UnorderedListOutlined"
                };
                foreach (var item in root.Value)
                {
                    var subMenu = new AntdUI.MenuItem()
                    {
                        Text = item.Text,
                        IconSvg = "UnorderedListOutlined"
                    };
                    rootMenu.Sub.Add(subMenu);
                }
                menuLeft.Items.Add(rootMenu);
            }
        }

        private void LoadPage()
        {
            for (int i = 0; i < 20; i++)
            {
                AntdUI.TabPage page = new AntdUI.TabPage() { Text = $"页面{i + 1}" };
                tabsMain.Pages.Add(page);
            }
        }
    }
}
