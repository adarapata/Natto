using UnityEngine;
using System.Collections;

namespace ActiveRecord {
    public class DbNameCarrier : MonoBehaviour {

    public string dbname = "database_name.db";
        void Awake()
        {
            SqliteDatabase.SetDatabaseName(dbname);
        }
        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

        }
    }
}