using UnityEngine;
using System.Collections;
using Natto.Database;

namespace Natto {
    public class DbNameCarrier : MonoBehaviour {

        public DatabaseType databaseType;
        public string dbname = "database_name.db";
        public string hostName,database,userName,port,password;
        void Awake()
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
        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

        }
    }
}