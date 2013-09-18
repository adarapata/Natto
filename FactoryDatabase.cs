using System.Collections;

public class FactoryDatabase {
    static public IDatabase CreateDatabase()
    {
        return SqliteDatabase.instance;
    }
}
