using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MySql.Data;
using MySql.Data.MySqlClient;
using Natto.Interface;

namespace Natto.Database {
    public class MysqlDatabase : IDatabase
    {
        static MysqlDatabase m_instance;

        static public MysqlDatabase instance
        {
            get
            {
                return m_instance;
            }
        }

        private MySqlConnection connector;
        private bool isConnected { get { return connector != null; } }

        private MysqlDatabase(string hostName, string database, string userName, string port, string password)
        {
           string conCmd = 
              "server="+hostName+";" +
              "database="+database+";" +
              "userid="+userName+";" +
              "port="+port+";" +
              "password="+password;
            connector = new MySqlConnection(conCmd) ;
        }

        public static void SetDatabaseName(string hostName, string database, string userName, string port, string password)
        {
            m_instance = new MysqlDatabase(hostName,database,userName,port,password);
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
            var cmd = new MySqlCommand(SQL, connector);

            // SQL実行
            var iAsync = cmd.BeginExecuteReader();
            while(!iAsync.IsCompleted){}
            var result = cmd.EndExecuteReader(iAsync);

            var list = new List<Dictionary<string, object>>();
            foreach (var colomn in GetValues(result)) { list.Add(colomn); }
            Close(result);
            return list;
        }

        private void Connect()
        {
           try {
                connector.Open();
           }catch(MySqlException ex) {
               Debug.Log(ex.ToString());
           }
        }

        private void Close(MySqlDataReader reader)
        {
             reader.Close();
             reader.Dispose();
             connector.Clone();
        }

        private IEnumerable<Dictionary<string, object>> GetValues(MySqlDataReader result)
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