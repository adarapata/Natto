using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace ActiveRecord {
    public class SqliteDatabase : IDatabase
    {
        static SqliteDatabase m_instance;

        private string dbName;
        private SqliteConnection connector;

        static public SqliteDatabase instance
        {
            get
            {
                return m_instance;
            }
        }

        private bool isConnected { get { return connector != null; } }

        private SqliteDatabase(string db)
        {
            dbName = db;
        }

        public static void SetDatabaseName(string databaseName)
        {
            m_instance = new SqliteDatabase(databaseName);
        }
        /// <summary>
        /// 任意のSQLを実行します
        /// </summary>
        /// <param name="SQL">SQL文</param>
        /// <returns>結果レコード群</returns>
        public List<Dictionary<string, object>> ExecuteSQL(string SQL)
        {
            Connect();

            // SQLコマンドオブジェクトの作成
            var cmd = new SqliteCommand(SQL, connector);

            // SQL実行
           var result = cmd.ExecuteReader();

           var list = new List<Dictionary<string, object>>();
           foreach (var colomn in GetValues(result)) { list.Add(colomn); }
           Close();
           return list;
        }

        private void Connect()
        {
            string connectPath = "uri=file:" + Application.streamingAssetsPath + "/" + dbName + ";";
            connector = new SqliteConnection(connectPath);
            // DBに接続
            connector.SetPassword("");
            connector.Open();
        }

        private void Close()
        {
            connector.Close();
        }

        private IEnumerable<Dictionary<string, object>> GetValues(SqliteDataReader result)
        {
            while (result.Read())
            {
                Dictionary<string, object> fields = new Dictionary<string, object>();
                int count = result.FieldCount;
                for (int i = 0; i < count; i++)
                {
                    fields.Add(result.GetName(i), result.GetValue(i));
                }
                yield return fields;
            }
        }
    }
}