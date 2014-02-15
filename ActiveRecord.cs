using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using Natto.Interface;

namespace Natto
{
    public class ActiveRecord<T> : IDataAccessObject
                         where T : IDataAccessObject, new()
    {
        virtual public string tableName { get { return "Active"; } }
        public int id {
            get {
               if(records.ContainsKey("id")) return GetInt("id"); 
               return 0;
            }
        }
        public ActiveRecord(){}

        protected Dictionary<string, object> records;
        public object this[string key]
        {
            get { return records[key]; }
            set
            {
                if(records == null) records = new Dictionary<string, object>();
                records[key] = value;
            }
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
            string sql = SqlBuilder.CreateSelectSql(new T().tableName);
            foreach (var colomn in db.ExecuteSQL(sql)) {
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

        public static void Create<T> (T attribute) where T : ActiveRecord<T>, new()
        {
            string sql = SqlBuilder.CreateInsertSql(attribute.tableName, attribute.records);
            db.ExecuteSQL (sql);
        }

        public static void Update<T> (T attribute) where T : ActiveRecord<T>, new()
        {
            if (attribute.id == 0) {
                Create (attribute);
                return;
            }
            string sql = SqlBuilder.CreateUpdteSql(attribute.tableName, attribute.records);
            db.ExecuteSQL (sql);
        }

        public static void Delete<T> (T attribute) where T : ActiveRecord<T>, new()
        {
            string sql = SqlBuilder.CreateDeleteSql(attribute.tableName, attribute.records);
            db.ExecuteSQL (sql);
        }

        public static void ClearCache ()
        {
            cache = null;
        }

        public void Mapping(Dictionary<string, object> datas)
        {
            records = datas;
        }

        protected int GetInt(string key)
        {
            return Convert.ToInt32(this[key]);
        }

        protected float GetFloat(string key)
        {
            return Convert.ToSingle(this[key]);
        }

        protected string GetString(string key)
        {
            return (string)(this[key]);
        }

        protected bool GetBool(string key)
        {
            return Convert.ToBoolean(this[key]);
        }
    }
}