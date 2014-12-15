using System.Collections;
using Natto.Database;
using Natto.Interface;

namespace Natto {
    public class FactoryDatabase {
        static public DatabaseType databaseType { get; set; }
        static public IDatabase CreateDatabase()
        {
            LoadDatabaseConfig ();
            switch(databaseType)
            {
                case DatabaseType.SQLite: return SqliteDatabase.instance;
                case DatabaseType.MySQL: return MysqlDatabase.instance;
            }
            UnityEngine.Debug.Log("No Setting Database Type");
            return null;
        }

        static private void LoadDatabaseConfig()
        {
            DatabaseConfig config = UnityEngine.Resources.Load ("DatabaseConfig") as DatabaseConfig;
            config.Initialize ();
        }
    }
}