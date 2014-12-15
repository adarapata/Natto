using System.Collections;
using Natto.Database;
using Natto.Interface;

namespace Natto {
    public class FactoryDatabase {
        static public DatabaseType databaseType { get; set; }
        static public IDatabase CreateDatabase()
        {
            switch(databaseType)
            {
                case DatabaseType.SQLite: return SqliteDatabase.instance;
                case DatabaseType.MySQL: return MysqlDatabase.instance;
            }
            UnityEngine.Debug.Log("No Setting Database Type");
            return null;
        }
    }
}