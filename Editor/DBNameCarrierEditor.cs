using UnityEngine;
using System.Collections;
using UnityEditor;
using Natto;

namespace Natto.Editor {
    [CustomEditor(typeof(Natto.DbNameCarrier))]
    public class DBNameCarrierEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            var carrier = target as DbNameCarrier;
            carrier.databaseType = (DatabaseType)EditorGUILayout.EnumPopup("Database Type",carrier.databaseType);
            ShowDatabaseConfigField(carrier);
        }

        private void ShowDatabaseConfigField(DbNameCarrier db)
        {   
            switch(db.databaseType)
            {
                 case DatabaseType.SQLite:
                     ShowSQLiteConfigField(db);
                     break;
                 case DatabaseType.MySQL:
                     ShowMySQLConfigField(db);
                     break;
            }
        }
        
        private void ShowSQLiteConfigField(DbNameCarrier carrier)
        {
            carrier.dbname = EditorGUILayout.TextField("fileName", carrier.dbname);         
        }
        
        private void ShowMySQLConfigField(DbNameCarrier carrier)
        {
            carrier.hostName = EditorGUILayout.TextField("hostName", carrier.hostName);
            carrier.userName = EditorGUILayout.TextField("userName", carrier.userName);
            carrier.database = EditorGUILayout.TextField("database", carrier.database);
            carrier.port = EditorGUILayout.TextField("port", carrier.port);
            carrier.password = EditorGUILayout.TextField("password", carrier.password);
        }
    }
}