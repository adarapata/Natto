using System.Collections;

namespace ActiveRecord {
    public class FactoryDatabase {
        static public IDatabase CreateDatabase()
        {
            return SqliteDatabase.instance;
        }
    }
}