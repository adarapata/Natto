using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Natto.Interface {
    public interface IDatabase
    {
        List<Dictionary<string, object>> ExecuteSQL(string sql);
    }
}