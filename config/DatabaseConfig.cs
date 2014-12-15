using UnityEngine;
using System.Collections;
using Natto.Database;

namespace Natto {
	public class DatabaseConfig : ScriptableObject {

        public DatabaseType databaseType;
        public string dbname = "database_name.db";
        public string hostName,database,userName,port,password;

        public void Initialize()
        {
            switch(databaseType)
            {
            case DatabaseType.SQLite: 
                SqliteDatabase.SetDatabaseName(dbname);
                break;
            case DatabaseType.MySQL:
                MysqlDatabase.SetDatabaseName(hostName,database,userName,port,password);
                break;
            }
            FactoryDatabase.databaseType = databaseType;
        }
    }
}