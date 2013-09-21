using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDatabase
{
    List<Dictionary<string, object>> ExecuteSQL(string sql);
}
