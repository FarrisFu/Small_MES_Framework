using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmSetting
{
    public class SettingParameters
    {
        public Setting1 setting1 { get; set; } = new Setting1();
        public Setting2 setting2 { get; set; } = new Setting2();
    }
    public class Setting1
    {
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public string Parameter6 { get; set; }
    }
    public class Setting2
    {
        public string Parameter21 { get; set; }
        public string Parameter22 { get; set; }
        public string Parameter23 { get; set; }
        public string Parameter24 { get; set; }
        public string Parameter25 { get; set; }
        public string Parameter26 { get; set; }
    }

}
