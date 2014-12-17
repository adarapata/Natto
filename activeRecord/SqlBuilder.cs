using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Natto {
    /// <summary>
    /// SQL文を作成する
    /// </summary>
    public class SqlBuilder {
        static public string CreateUpdteSql(string table, Dictionary<string, object> colomns, string primaryKey)
        {
            string query = "UPDATE " + table + " SET ";
            foreach(var key in colomns.Keys)
            {
                query += key + " = '" + colomns[key].ToString() + "',";
            }
            query = query.Remove(query.Length-1);
            query += " WHERE " + primaryKey + " = " + colomns[primaryKey].ToString() + ";";
            return query;
        }

        static public string CreateInsertSql(string table, Dictionary<string, object> colomns, string primaryKey)
        {
            string query = "INSERT INTO " + table + " (";
            string colomnQuery = "";
            string valueQuery = "VALUES(";
            foreach(var key in colomns.Keys)
            {
                if(key == primaryKey)continue;
                colomnQuery += key + ",";
                valueQuery += "'" + colomns[key] + "',";
            }
            colomnQuery = colomnQuery.Remove(colomnQuery.Length-1);
            valueQuery = valueQuery.Remove(valueQuery.Length-1);

            colomnQuery += ") ";
            valueQuery += ") ";

            query += colomnQuery + valueQuery + ";";
            return query;
        }

        static public string CreateDeleteSql(string table, Dictionary<string, object> colomn, string primaryKey)
        {
            string query = "DELETE FROM " + table + " WHERE " + primaryKey + " = " + colomn[primaryKey].ToString() + ";";
            return query;
        }

        static public string CreateSelectSql(string table)
        {
            string query = "SELECT * FROM " + table + ";";
            return query;
        }
    }
}
