using ScintillaNET;
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

namespace FrmLogViewer
{
    public partial class FrmLogViewer : AntdUI.Window
    {
        #region 变量
        private List<LogEntity> allLogFiles = new List<LogEntity>();
        private List<LogEntity> searchLogFiles = new List<LogEntity>();
        private LogOperation logOperation = new LogOperation();
        private string directoryPath;
        private bool isLoaded = false; // 确保只加载一次
        private DateTime[] bufferDate = null;
        private string searchKey = string.Empty; // 搜索关键字
        private LogEntity markLogEntity = null; // 用于标记的日志实体
        private int junpToIndex = -99;
        AntdUI.FormFloatButton FloatButton = null;
        Dictionary<int, string> strLbCount = new Dictionary<int, string>();//1是日志文件总数量，2是模糊搜索数量,3是当前文件匹配数量
        Label lbCount = new Label();
        Label lbLogAdress = new Label();

        #endregion

        public FrmLogViewer(object parameter = null)
        {
            InitializeComponent();
            directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            tabLogs.Columns = new AntdUI.ColumnCollection
            {
                new AntdUI.Column("Type","类型").SetSortOrder(),
                new AntdUI.Column("Level","级别").SetSortOrder(),
                new AntdUI.Column("Size","文件大小").SetSortOrder(),
                new AntdUI.Column("CreatTime","创建时间").SetSortOrder(),
                new AntdUI.Column("ModifyTime","修改时间").SetSortOrder(),
                new AntdUI.Column("FileAdress","文件地址").SetSortOrder()
            };
        }
        /// <summary>
        /// 窗体加载事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogViewer_Load(object sender, EventArgs e)
        {
            this.datePickerRange1.Value = new DateTime[] { DateTime.Today, DateTime.Today };
            InitScintilla();
            this.datePickerRange1.ValueChanged += new AntdUI.DateTimesEventHandler(this.DateTime_ValueChanged);
            btnNext.Click += (s, ev) => JumpToLine(false); // 下一行
            btnBack.Click += (s, ev) => JumpToLine(true); // 下一行
            GetFilesListByDate();
        }
        #region 函数
        /// <summary>
        /// 初始化 Scintilla
        /// </summary>
        private void InitScintilla()
        {
            scintilla.Styles[ScintillaNET.Style.Default].Font = "微软雅黑";
            scintilla.Styles[ScintillaNET.Style.Default].Size = 9;
            scintilla.StyleClearAll();

            // 设置 Indicator（用于高亮）
            scintilla.Indicators[0].Style = IndicatorStyle.StraightBox;
            scintilla.Indicators[0].Under = true;
            scintilla.Indicators[0].ForeColor = Color.Blue;
            scintilla.Indicators[0].OutlineAlpha = 50;
            scintilla.Indicators[0].Alpha = 30;

            // 行号边距配置
            var margin = scintilla.Margins[0];
            margin.Type = MarginType.Number;
            margin.Width = 40;
            margin.Sensitive = false;
            margin.Mask = 0;
            scintilla.WrapMode = WrapMode.None;

            scintilla.TextChanged += (s, e) => AdjustLineNumberMarginWidth();
        }
        /// <summary>
        /// 根据日期范围获取日志文件列表
        /// </summary>
        private void GetFilesListByDate()
        {
            DateTime[] dateTime = this.datePickerRange1.Value;
            if (bufferDate != null && bufferDate.Length == 2)
            {
                // 如果日期范围没有变化，则不重新加载
                if (dateTime[0].Date == bufferDate[0].Date && dateTime[1].Date == bufferDate[1].Date)
                {
                    return;
                }
            }
            scintilla.Text = string.Empty; // 清空文本内容
            bufferDate = dateTime; // 缓存当前日期范围
            dateTime[1] = dateTime[1].AddDays(1).AddTicks(-1); // 确保结束时间包含当天的最后一刻
            allLogFiles = logOperation.GetLogFiles(dateTime[0], dateTime[1], directoryPath);
            ModifyDataSource(allLogFiles);
            strLbCount[1] = $"日志文件总数量：{allLogFiles.Count}";
            lbCount.Text = strLbCount[1];

            if (!string.IsNullOrEmpty(this.txtSearchKey.Text.Trim()))
                SearchKey();
        }


        private void ModifyDataSource(List<LogEntity> data)
        {
            tabLogs.DataSource = data;
            //this.bindingSourceLog.DataSource = data;
            //this.bindingSourceLog.ResetBindings(false);
        }

        /// <summary>
        /// 展示文本
        /// </summary>
        /// <param name="rowData"></param>
        private void ShowContent(LogEntity rowData)
        {
            string fileContent = logOperation.GetFileContent(rowData.FileAdress);
            scintilla.Text = string.Empty;
            CloseFloatButton();
            scintilla.Text = fileContent;
            scintilla.Refresh();
            lbLogAdress.Text = $"当前日志文件地址：{rowData.FileAdress}";
            if (string.IsNullOrEmpty(searchKey) || rowData.RowInformation.Count < 1)
            {
                return;
            }
            // 应用高亮
            Task.Run(() =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    MarkTextAsyc(rowData);
                }));
            });
        }

        /// <summary>
        /// 高亮文本
        /// </summary>
        /// <param name="rowData"></param>
        private void MarkTextAsyc(LogEntity rowData)
        {
            lbCount.Text = $"当前文件匹配数量：{rowData.RowInformation.Count}";
            markLogEntity = rowData;
            scintilla.IndicatorCurrent = 0;
            scintilla.IndicatorClearRange(0, scintilla.TextLength);
            foreach (var item in rowData.RowInformation)
            {
                if (item.RowIndex < scintilla.Lines.Count)
                {
                    var line = scintilla.Lines[item.RowIndex];
                    scintilla.IndicatorFillRange(line.Position + item.CharIndex, searchKey.Length);
                }
            }
            JumpToLine();
            OpenFloatButton();
        }


        /// <summary>
        /// 文本改变时调整行号宽度
        /// </summary>
        private void AdjustLineNumberMarginWidth()
        {
            if (scintilla.Lines.Count < 1) return;
            int maxLineNumber = Math.Max(1, scintilla.Lines.Count);  // 至少1行
            int digits = maxLineNumber.ToString().Length;
            int requiredWidth = scintilla.TextWidth(ScintillaNET.Style.LineNumber, new string('9', digits));
            scintilla.Margins[0].Width = requiredWidth + 5;
        }

        /// <summary>
        /// 跳转到下一行或上一行
        /// </summary>
        /// <param name="back"></param>
        public void JumpToLine(bool back = false)
        {
            try
            {
                if (markLogEntity == null && markLogEntity.RowInformation.Count < 1) return;

                if (junpToIndex == -99)
                {
                    junpToIndex = 0; // 重置为第一行
                }
                else
                {
                    if (back)
                    {
                        junpToIndex--; // 跳转到上一行
                        if (junpToIndex < 0 || junpToIndex >= markLogEntity.RowInformation.Count - 1)
                            junpToIndex = markLogEntity.RowInformation.Count - 1;// 重置为最后一行
                    }
                    else
                    {
                        junpToIndex++; // 跳转到下一行
                        if (junpToIndex < 0 || junpToIndex >= markLogEntity.RowInformation.Count - 1)
                            junpToIndex = 0; // 重置为第一行                       
                    }
                }

                int targetLine = markLogEntity.RowInformation[junpToIndex].RowIndex;
                targetLine += 1; // 行号从1开始
                if (targetLine < 0)
                    targetLine = 0;
                if (targetLine >= scintilla.Lines.Count)
                    targetLine = scintilla.Lines.Count - 1;

                int position = scintilla.Lines[targetLine].Position;

                scintilla.CurrentPosition = position;
                scintilla.SelectionStart = position;
                scintilla.SelectionEnd = position;
                scintilla.ScrollCaret();
            }
            catch (Exception ex)
            {
                LogService.Error("JumpToLine跳转行失败", ex);
            }
        }
        /// <summary>
        /// 显示悬浮图标
        /// </summary>
        private void OpenFloatButton()
        {
            panFloat.Visible = true;
        }

        private void CloseFloatButton()
        {
            panFloat.Visible = false;
        }

        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <returns></returns>
        private void SearchKey()
        {
            try
            {
                string key = txtSearchKey.Text.Trim();
                if (string.IsNullOrEmpty(key))
                {
                    //JMSMessage.HintDialog("请输入搜索关键字！");
                    btnOK.PerformClick(); // 取消搜索
                    return;
                }
                searchKey = key;
                searchLogFiles = logOperation.SearchFilesWithContextByRow(directoryPath, searchKey, allLogFiles, out int allMatchCount);
                if (searchLogFiles.Count > 0)
                {
                    ModifyDataSource(searchLogFiles);
                    strLbCount[2] = $"符合搜索结果文件数量：{searchLogFiles.Count}，总匹配数量：{allMatchCount}";
                    lbCount.Text = strLbCount[2];
                    scintilla.Text = string.Empty;
                    CloseFloatButton();
                }
                else
                {
                    //JMSMessage.HintDialog("未找到相关日志信息！");
                }
            }
            catch (Exception ex)
            {
                LogService.Error("模糊搜索失败", ex);
            }

        }
        #endregion
        /// <summary>
        /// 日期范围预设点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datePickerRange1_PresetsClickChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            try
            {
                string value = e.Value as string;
                switch (value)
                {
                    case "今天":
                        this.datePickerRange1.Value = new DateTime[] { DateTime.Today, DateTime.Today };
                        break;
                    case "昨天":
                        this.datePickerRange1.Value = new DateTime[] { DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1) };
                        break;
                    case "本月":
                        this.datePickerRange1.Value = new DateTime[] { new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Today };
                        break;
                    case "上月":
                        this.datePickerRange1.Value = new DateTime[] { new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1) };
                        break;
                    case "过去3天":
                        this.datePickerRange1.Value = new DateTime[] { DateTime.Today.AddDays(-3), DateTime.Today };
                        break;
                    case "过去7天":
                        this.datePickerRange1.Value = new DateTime[] { DateTime.Today.AddDays(-7), DateTime.Today };
                        break;
                    case "过去15天":
                        this.datePickerRange1.Value = new DateTime[] { DateTime.Today.AddDays(-15), DateTime.Today };
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogService.Error("日期范围预设点击事件处理失败", ex);
                DialogService.Error("错误", "日期范围预设点击事件处理失败");
            }
        }


        /// <summary>
        /// 日期 范围选择器值改变事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTime_ValueChanged(object sender, EventArgs e)
        {
            GetFilesListByDate();
        }

        private void tabLogs_CellDoubleClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Record is LogEntity rowData)
            {
                if (rowData != null)
                    ShowContent(rowData);
            }
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SearchKey();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ModifyDataSource(allLogFiles);
            scintilla.Text = string.Empty;
            CloseFloatButton();
            txtSearchKey.Clear();
            searchKey = string.Empty;
            lbLogAdress.Text = $"当前日志文件地址：";
            lbCount.Text = strLbCount[1];
        }
    }
}
