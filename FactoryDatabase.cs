using System.Collections;
using Natto.Database;
using Natto.Interface;

namespace Natto {
    public class FactoryDatabase {
        static public IDatabase CreateDatabase()
        {
            return SqliteDatabase.instance;
        }
    }
}