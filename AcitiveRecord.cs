using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class AcitiveRecord<T> where T : IDataAccessObject, new()
{
    static protected IDatabase m_db;
    private static List<T> cache;

    static protected IDatabase db 
    {
        get 
        {
            if (m_db == null) m_db = FactoryDatabase.CreateDatabase();
            return m_db;
        } 
    }

    public static List<T> FindAll()
    {
        if (cache != null) { return cache; }

        cache = new List<T>();
        List<T> list = new List<T>();
        string tableName = new T().tableName;
        foreach (var colomn in db.ExecuteSQL("SELECT * FROM " + tableName + ";"))
        {
            var dao = new T();
            dao.Mapping(colomn);
            list.Add(dao);
            cache.Add(dao);
        }
        return list;
    }

    public static T Find(Func<T, bool> predicate)
    {
        return FindAll().Single(predicate);
    }

    public static List<T> Where(Func<T, bool> predicate)
    {
        return FindAll().Where(predicate).ToList();
    }

    public static void Create<T>(T attribute) where T : IDataAccessObject, ICreateSQL, new()
    {
        string sql = "INSERT INTO " + new T().tableName + attribute.CreateSQL();
        var result = db.ExecuteSQL(sql);
    }

    public static void Update<T>(T attribute) where T : IDataAccessObject, ICreateSQL, new()
    {
        if (attribute.id == 0) { Create(attribute); return; }
        string sql = "UPDATE " + new T().tableName +" SET " + attribute.UpdateSQL();
        var result = db.ExecuteSQL(sql);
    }

    public static void Delete<T>(T attribute) where T : IDataAccessObject, IDeleteSQL, new()
    {
        if (!attribute.deleteFlag) return;
        string sql = "DELETE FROM " + new T().tableName + " WHERE id = " + attribute.id.ToString() + ";";
        var result = db.ExecuteSQL(sql);
    }

    public static void ClearCache()
    {
        cache = null;
    }
}
