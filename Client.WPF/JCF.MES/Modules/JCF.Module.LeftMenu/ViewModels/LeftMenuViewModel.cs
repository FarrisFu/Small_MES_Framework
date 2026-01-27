using JCF.Common;
using JCF.Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JCF.Module.LeftMenu.ViewModels
{
    public class LeftMenuViewModel : BindableBase
    {
        IEventAggregator eventAggregator;
        IModuleManager moduleManager;
        public LeftMenuViewModel(IEventAggregator eventAggregator,IModuleManager moduleManager)
        {
            Message = "菜单栏";
            //regionManager = region;
            this.eventAggregator = eventAggregator;
            this.moduleManager = moduleManager;

            //for (int i = 0; i < 100; i++)
            //{
            //    Menus.Add(new Menu { Title = "首页" + i, ViewName = "HomePageView", ModuleName = "HomePageModule" });
            //}

        }
        #region 通知属性

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private List<Menu> _Menus = new List<Menu>()
        {
            new Menu(){ Title="首页", ViewName="HomePageView", ModuleName="HomePageModule"},
            new Menu(){ Title="订单页", ViewName="OrderView", ModuleName="OrderModule"},
            new Menu(){ Title="数据统计页", ViewName="DataReportView", ModuleName="DataReportModule"}
        };

        public List<Menu> Menus
        {
            get { return _Menus; }
            set { SetProperty(ref _Menus, value); }
        }
        #endregion
        #region 命令
        private DelegateCommand _LoadedCommand;
        public DelegateCommand LoadedCommand =>
            _LoadedCommand ?? (_LoadedCommand = new DelegateCommand(ExecuteLoadedCommand));

        void ExecuteLoadedCommand()
        {
            foreach (var item in Menus)
            {
                moduleManager.LoadModule(item.ModuleName);
            }

            OpenCommand.Execute(Menus.First(p=>p.ModuleName== "HomePageModule"));
        }

        private DelegateCommand<Menu> _OpenCommand;
        public DelegateCommand<Menu> OpenCommand =>
            _OpenCommand ?? (_OpenCommand = new DelegateCommand<Menu>(ExecuteOpenCommand));

        void ExecuteOpenCommand(Menu value)
        {
            //regionManager.RequestNavigate("TabRegion", value.ViewName);
            eventAggregator.GetEvent<OpenMenuEvent>().Publish(value);
        }
        #endregion
    }
}
