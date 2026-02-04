using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolHelperClass.DbEntity
{
    [SugarTable("TAB_OperationLog", TableDescription = "生产日志表")]
    public class OperationLogEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
        public int Id { get; set; }


        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string Code { get; set; }

        [SugarColumn(ColumnDataType = "INTEGER")]
        public int OrderId { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string ProcessName { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string Producer { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string ProductionTime { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string Remark { get; set; }

       

       
    }
}
