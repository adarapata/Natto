using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using Natto.Interface;

namespace Natto
{
    public class ActiveRecord<T> where T : IDataAccessObject, new()
    {
        protected Dictionary<string, object> records;
        public object this[string key]
        {
            get { return records[key]; }
            set { records[key] = value; }
        }

        static protected IDatabase m_db;
        private static List<T> cache;

        static protected IDatabase db {
            get {
                if (m_db == null)
                    m_db = FactoryDatabase.CreateDatabase ();
                    return m_db;
                } 
        }

        public static List<T> FindAll ()
        {
            if (cache != null) return cache;
            cache = new List<T> ();
            List<T> list = new List<T> ();
            string tableName = new T ().tableName;
            foreach (var colomn in db.ExecuteSQL("SELECT * FROM " + tableName + ";")) {
                var dao = new T ();
                dao.Mapping(colomn);
                list.Add (dao);
                cache.Add (dao);
            }
            return list;
        }

        public static T Find (Func<T, bool> predicate)
        {
            return FindAll ().Single (predicate);
        }

        public static List<T> Where (Func<T, bool> predicate)
        {
            return FindAll ().Where (predicate).ToList ();
        }

        public static void Create<T> (T attribute) where T : IDataAccessObject, ICreateSQL, new()
        {
            string sql = "INSERT INTO " + new T ().tableName + attribute.CreateSQL ();
            var result = db.ExecuteSQL (sql);
        }

        public static void Update<T> (T attribute) where T : IDataAccessObject, ICreateSQL, new()
        {
            if (attribute.id == 0) {
                Create (attribute);
                return;
            }
            string sql = "UPDATE " + new T ().tableName + " SET " + attribute.UpdateSQL ();
            var result = db.ExecuteSQL (sql);
        }

        public static void Delete<T> (T attribute) where T : IDataAccessObject, IDeleteSQL, new()
        {
            if (!attribute.deleteFlag) return;
            string sql = "DELETE FROM " + new T ().tableName + " WHERE id = " + attribute.id.ToString () + ";";
            var result = db.ExecuteSQL (sql);
        }

        public static void ClearCache ()
        {
            cache = null;
        }

        public void Mapping(Dictionary<string, object> datas)
        {
            records = datas;
        }

        public int GetInt(string key)
        {
            return Convert.ToInt32(this[key]);
        }

        public string GetString(string key)
        {
            return (string)(this[key]);
        }

        public bool GetBool(string key)
        {
            return Convert.ToBoolean(this[key]);
        }

        public void SetInt(string key, int value)
        {
            this[key] = value;
        }

        public void SetString(string key, string value)
        {
            this[key] = value;
        }

        public void SetBool(string key, bool value)
        {
            this[key] = value;
        }
    }
}