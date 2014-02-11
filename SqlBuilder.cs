using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// SQL文を作成する
/// </summary>
public class SqlBuilder {
    static public string CreateUpdteSql(string table, Dictionary<string, object> colomns)
    {
        string query = "UPDATE " + table + " SET ";
        foreach(var key in colomns.Keys)
        {
            query += key + " = '" + colomns[key].ToString() + "',";
        }
        query = query.Remove(query.Length-1);
        query += " WHERE id = " + colomns["id"].ToString() + ";";
        return query;
    }

    static public string CreateInsertSql(string table, Dictionary<string, object> colomns)
    {
        string query = "INSERT INTO " + table;
        foreach(var key in colomns.Keys)
        {
             query += key + " = '" + colomns[key].ToString() + "',";
        }
        query = query.Remove(query.Length-1);
        query += " WHERE id = " + colomns["id"].ToString() + ";";
        return query;
    }
}
