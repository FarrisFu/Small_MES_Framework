using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;
using ToolHelperClass.DbService;
using Winform_Framework.Service.LocalDB;
using System.Data.SQLite;
namespace Winform_Framework.Service
{
    public static class LocalDataService
    {
       static SqlsugarDbRepository<DictionaryEntity> dbDictionaryEntity;
         static LocalDataService()
        {

            SqlsugarDb sqlsugarDb=new SqlsugarDb(Application.StartupPath + "\\LocalData\\LocalData.db");
            Type[] tables = new Type[] { typeof(DictionaryEntity) };
            //tables.Append(typeof(DictionaryEntity));           
            sqlsugarDb.InitialTables(tables);


            dbDictionaryEntity = new SqlsugarDbRepository<DictionaryEntity>(sqlsugarDb.Db);           
        }

        public static List<DictionaryEntity> GetMeunLIst()
        {
            return dbDictionaryEntity.GetList(p => (p.DictType == "menu1" || p.DictType == "menu2"));
        }

    }
}
