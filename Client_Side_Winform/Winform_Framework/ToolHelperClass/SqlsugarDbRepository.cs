using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToolHelperClass.DbService;

namespace ToolHelperClass
{
    public class SqlsugarDbRepository<T> where T : class, new()
    {
        private readonly SqlSugarScope _db;
        public SqlsugarDbRepository(SqlSugarScope db)
        {          
            _db = db;
        }

        // 添加
        public int Add(T entity)
        {
            return _db.Insertable(entity).ExecuteCommand();
        }

        // 批量添加
        public int AddRange(List<T> entities)
        {
            return _db.Insertable(entities).ExecuteCommand();
        }

        // 删除
        public int Delete(object id)
        {
            return _db.Deleteable<T>().In(id).ExecuteCommand();
        }

        // 更新
        public int Update(T entity)
        {
            return _db.Updateable(entity).ExecuteCommand();
        }

        // 查询单个
        public T GetById(object id)
        {
            return _db.Queryable<T>().InSingle(id);
        }

        // 查询多个
        public List<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return _db.Queryable<T>().Where(predicate).ToList();
        }

        // 查询所有
        public List<T> GetAll()
        {
            return _db.Queryable<T>().ToList();
        }

        // 执行单条 SQL 查询
        public List<dynamic> ExecuteSingleQuery(string sql)
        {
            return _db.Ado.SqlQuery<dynamic>(sql);
        }

        // 执行多条 SQL 语句，带事务支持
        public bool ExecuteMultipleQueriesWithTransaction(List<string> sqlList)
        {
            // 开始事务
            var isSuccess = false;
            _db.Ado.BeginTran();

            try
            {
                foreach (var sql in sqlList)
                {
                    _db.Ado.ExecuteCommand(sql);
                }
                // 提交事务
                _db.Ado.CommitTran();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                // 回滚事务
                _db.Ado.RollbackTran();
                Console.WriteLine($"Error executing SQL: {ex.Message}");
            }

            return isSuccess;
        }
    }

}

