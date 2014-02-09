using System.Collections;
using ActiveRecord.Database;
using ActiveRecord.Interface;

namespace ActiveRecord {
    public class FactoryDatabase {
        static public IDatabase CreateDatabase()
        {
            return SqliteDatabase.instance;
        }
    }
}