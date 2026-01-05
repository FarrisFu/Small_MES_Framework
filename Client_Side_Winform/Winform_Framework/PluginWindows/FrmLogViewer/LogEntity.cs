using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogViewer
{
    public class LogEntity
    {
        public string KeyContent { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
        public string FileAdress { get; set; }
        public string CreatTime { get; set; }
        public string ModifyTime { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public List<RowData> RowInformation { get; set; } = new List<RowData>();


    }
    public class RowData
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// 行所在起始地址
        /// </summary>
        public int CharIndex { get; set; }
        /// <summary>
        /// 全局行号索引
        /// </summary>
        public int GlobalRowSIndex { get; set; }
    }
}
