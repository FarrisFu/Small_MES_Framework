using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;

namespace FrmLogViewer
{
    public class LogOperation
    {
        public string ErrorMessage { get; set; }


        /// <summary>
        /// 筛选符合日期的日志文件
        /// </summary>
        /// <param name="startTiem"></param>
        /// <param name="endTime"></param>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public List<LogEntity> GetLogFiles(DateTime startTiem, DateTime endTime, string directoryPath)
        {
            List<LogEntity> logFiles = new List<LogEntity>();

            if (Directory.Exists(directoryPath))
            {
                string[] fileList = Directory.GetFiles(directoryPath, "*.log", SearchOption.AllDirectories);
                foreach (var item in fileList)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        long fileSizeBytes = fileInfo.Length;
                        if (fileSizeBytes == 0) continue;
                        if (fileSizeBytes > 50 * 1024 * 1024)
                        {
                            LogService.Warn($"文件过大，跳过处理: {item}");
                            continue; // 大于50MB的文件不显示
                        }

                        DateTime createTime = fileInfo.CreationTime;
                        DateTime modifyTime = fileInfo.LastWriteTime;

                        if ((createTime >= startTiem && createTime <= endTime) ||
                            (modifyTime >= startTiem && modifyTime <= endTime))
                        {
                            string sizeStr;
                            if (fileSizeBytes >= 1024 * 1024)
                                sizeStr = (fileSizeBytes / 1024.0 / 1024.0).ToString("F2") + " MB";
                            else
                                sizeStr = (fileSizeBytes / 1024.0).ToString("F2") + " KB";

                            logFiles.Add(new LogEntity()
                            {
                                FileAdress = item,
                                CreatTime = createTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                ModifyTime = modifyTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                Level = Path.GetFileName(item),
                                Type = "DeviceLogs",
                                Size = sizeStr
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        LogService.Error("获取日志文件信息失败", ex);
                        DialogService.Error("错误", "获取日志文件信息失败");
                    }
                }
            }
            else
            {
                LogService.Error("指定的目录不存在");
                DialogService.Error("错误", "指定的目录不存在");
            }
            return logFiles;
        }

        /// <summary>
        /// 模糊搜索指定目录下的所有文件，查找包含指定关键字的内容，并输出相关上下文信息。
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="keyword"></param>
        public List<LogEntity> SearchFilesWithContext(string directoryPath, string keyword, List<LogEntity> allfiles)
        {
            List<LogEntity> results = new List<LogEntity>();
            foreach (var file in allfiles)
            {

                try
                {
                    string content = File.ReadAllText(file.FileAdress, Encoding.GetEncoding("GBK"));
                    int index = 0;
                    LogEntity logEntity = null;

                    while ((index = content.IndexOf(keyword, index, StringComparison.OrdinalIgnoreCase)) != -1)
                    {
                        int start = Math.Max(0, index - 50);
                        int length = Math.Min(100 + keyword.Length, content.Length - start);

                        string context = content.Substring(start, length).Replace("\r", "").Replace("\n", " ");

                        index += keyword.Length;

                        if (logEntity == null)
                        {
                            logEntity = new LogEntity()
                            {
                                KeyContent = context,
                                Level = file.Level,
                                Type = "DeviceLogs",
                                FileAdress = file.FileAdress,
                                CreatTime = file.CreatTime,
                                ModifyTime = file.ModifyTime
                            };
                        }
                        else
                        {

                        }


                    }
                    if (logEntity != null)
                    {
                        results.Add(logEntity);
                    }
                }
                catch (Exception ex)
                {
                    //JMSMessage.HintDialog($"读取文件出错: {file.FileAdress}, 错误: {ex.Message}");
                }
            }

            return results;
        }

        /// <summary>
        /// 模糊搜索指定目录下的所有文件，查找包含指定关键字的内容，并输出相关上下文信息。
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="keyword"></param>
        /// <param name="allfiles"></param>
        /// <param name="allMatchCount"></param>
        /// <returns></returns>
        public List<LogEntity> SearchFilesWithContextByRow(string directoryPath, string keyword, List<LogEntity> allfiles, out int allMatchCount)
        {
            List<LogEntity> results = new List<LogEntity>();
            allMatchCount = 0;
            foreach (var file in allfiles)
            {
                try
                {
                    using (var reader = new StreamReader(file.FileAdress, Encoding.GetEncoding("GBK")))
                    {
                        string line;
                        int lineIndex = 0;
                        LogEntity logEntity = null;

                        while ((line = reader.ReadLine()) != null)
                        {
                            int startIndex = 0;

                            // 忽略大小写查找关键字
                            while ((startIndex = line.IndexOf(keyword, startIndex, StringComparison.OrdinalIgnoreCase)) >= 0)
                            {
                                // 如果当前行包含关键字，创建或更新 LogEntity
                                if (logEntity == null)
                                {
                                    logEntity = new LogEntity()
                                    {
                                        Level = file.Level,
                                        Type = file.Type,
                                        Size = file.Size,
                                        FileAdress = file.FileAdress,
                                        CreatTime = file.CreatTime,
                                        ModifyTime = file.ModifyTime,
                                        RowInformation = new List<RowData>()
                                    };
                                }

                                // 添加当前匹配
                                logEntity.RowInformation.Add(new RowData() { RowIndex = lineIndex, CharIndex = startIndex });
                                // 继续搜索下一个匹配
                                startIndex += keyword.Length;
                            }
                            lineIndex++;
                        }

                        if (logEntity != null)
                        {
                            results.Add(logEntity);
                            // 累加匹配行数         
                            allMatchCount += logEntity.RowInformation.Count;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //JMSMessage.HintDialog($"读取文件出错: {file.FileAdress}, 错误: {ex.Message}");
                }
            }

            return results;
        }




        /// <summary>
        /// 大文件按行读取内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public StringBuilder ReadFileContentByLine(string filePath)
        {
            StringBuilder content = new StringBuilder();
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("GBK")))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        content.AppendLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage += $"读取文件失败: {filePath}, 错误: {ex.Message}";
            }
            return content;
        }

        /// <summary>
        /// 小文件直接读取内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileContent(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath, Encoding.GetEncoding("GBK"));
            }
            catch (Exception ex)
            {
                ErrorMessage += $"读取文件失败: {filePath}, 错误: {ex.Message}";
                return string.Empty;
            }
        }
    }
}
