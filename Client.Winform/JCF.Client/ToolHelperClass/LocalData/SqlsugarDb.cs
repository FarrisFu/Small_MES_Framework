using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SQLite;
namespace ToolHelperClass
{
    public class SqlsugarDb
    {
        #region 属性

        private readonly SqlSugarScope _scope;
        private readonly string _connectionString;

        #endregion
        #region 构造函数
        /// <summary>
        /// SqlsugarDbSqlite
        /// </summary>
        /// <param name="dbFilePath"></param>
        public SqlsugarDb( string dbFilePath)
        {
            try
            {
                //本地数据库地址
                _connectionString = $"DataSource={dbFilePath};Version=3;";
                //SqlSugarScope
                _scope = new SqlSugarScope(new ConnectionConfig()
                {
                    ConnectionString = _connectionString,
                    DbType = DbType.Sqlite,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                },
                db =>
                {
                    // 配置AOP
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        LogService.Debug($"SQL: {sql} \nParams: {string.Join(", ", pars.Select(p => p.ParameterName + "=" + p.Value))}");
                    };
                });
            }
            catch (Exception ex)
            {
                LogService.Error("初始化本地数据库失败:", ex);
                throw;
            }
           
        }
        #endregion

        #region 获取数据库操作实例
        /// <summary>
        /// 获取数据库操作实例
        /// </summary>
        public SqlSugarScope Db => _scope;
        #endregion



        #region 初始化数据库表结构
        /// <summary>
        /// 初始化数据库表结构
        /// </summary>
        public void InitialTables(params Type[] entityTypes)
        {
            try
            {
                LogService.Debug("初始化数据库表结构...");
                _scope.CodeFirst.InitTables(entityTypes);
            }
            catch (Exception ex)
            {
                LogService.Error("初始化本地数据库失败:", ex);
                throw;
            }
           
        }
        #endregion

        #region 初始化触发器
        /// <summary>
        /// 初始化数据库触发器
        /// </summary>
        public bool InitialTrigger(string triggerName, string triggerText)
        {
            if (string.IsNullOrEmpty(triggerText)) return true;

            try
            {
                //触发器已有脚本
                string triggerExistsSql = _scope.Ado.GetString($"SELECT sql FROM sqlite_master WHERE type='trigger' AND name='{triggerName}'").Replace("\r\n", " ").Trim();

                if (!String.Equals(triggerExistsSql, triggerText, StringComparison.OrdinalIgnoreCase))
                {
                    // 如果触发器存在，则先删除
                    if (!string.IsNullOrEmpty(triggerExistsSql))
                    {
                        int dropResult = _scope.Ado.ExecuteCommand($"DROP TRIGGER {triggerName};");
                    }
                    //执行语句
                    return _scope.Ado.ExecuteCommand(triggerText) == 0;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogService.Error($"创建触发器{triggerName}错误:", ex);
                return false;
            }
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _scope?.Dispose();
        }
        #endregion
    }
}
