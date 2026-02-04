using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;
using System.Data.SQLite;
using ToolHelperClass.LocalData.DbEntity;
using ToolHelperClass.DbEntity;
namespace ToolHelperClass
{
    public static class LocalDataService
    {
        static SqlsugarDbRepository<DictionaryEntity> dbDictionaryService;
        static SqlsugarDbRepository<MenuEntity> dbMenuService;
        static SqlsugarDbRepository<UserEntity> dbUserService;
        static LocalDataService()
        {

            SqlsugarDb sqlsugarDb = new SqlsugarDb(Application.StartupPath + "\\LocalData\\LocalData.db");
            Type[] tables = new Type[]
            {
                typeof(DictionaryEntity),
                typeof(UserEntity),
                typeof(MenuEntity)
            };
            sqlsugarDb.InitialTables(tables);


            dbDictionaryService = new SqlsugarDbRepository<DictionaryEntity>(sqlsugarDb.Db);
            dbMenuService = new SqlsugarDbRepository<MenuEntity>(sqlsugarDb.Db);
            dbUserService = new SqlsugarDbRepository<UserEntity>(sqlsugarDb.Db);
        }

        public static List<MenuEntity> GetMeunLIst()
        {
            return dbMenuService.GetList(p => (p.MenuType == "1" || p.MenuType == "2"));
        }

    }
}
