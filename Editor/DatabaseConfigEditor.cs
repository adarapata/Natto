using UnityEngine;
using System.Collections;
using UnityEditor;
using Natto;

namespace Natto.Editor
{
    [CustomEditor (typeof(Natto.DatabaseConfig))]
    public class DatabaseConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI ()
        {
            var config = target as DatabaseConfig;
            config.databaseType = (DatabaseType)EditorGUILayout.EnumPopup ("Database Type", config.databaseType);
            ShowDatabaseConfigField (config);
        }

        private void ShowDatabaseConfigField (DatabaseConfig config)
        {   
            switch (config.databaseType) {
            case DatabaseType.SQLite:
                ShowSQLiteConfigField (config);
                break;
            case DatabaseType.MySQL:
                ShowMySQLConfigField (config);
                break;
            }
        }

        private void ShowSQLiteConfigField (DatabaseConfig config)
        {
            config.dbname = EditorGUILayout.TextField ("fileName", config.dbname);         
        }

        private void ShowMySQLConfigField (DatabaseConfig config)
        {
            config.hostName = EditorGUILayout.TextField ("hostName", config.hostName);
            config.userName = EditorGUILayout.TextField ("userName", config.userName);
            config.database = EditorGUILayout.TextField ("database", config.database);
            config.port = EditorGUILayout.TextField ("port", config.port);
            config.password = EditorGUILayout.TextField ("password", config.password);
        }
    }
}