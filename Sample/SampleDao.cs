using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Natto;

public class SampleDao : ActiveRecord<SampleDao>
{
    public override string tableName { get { return "SampleTable"; } }

    public int param_int { get { return GetInt("param_int"); } set { this["param_int"] = value; } }
    public string param_string { get { return GetString("param_string"); } set { this["param_string"] = value; } }
    public bool param_bool { get { return GetBool("param_bool"); } set { this["param_bool"] = value; } }
    public int? param_int_null { get { return GetIntOrNull("param_int_null"); } set { this["param_int_null"] = value; } }
    public string param_string_null { get { return GetString("param_string_null"); } set { this["param_string_null"] = value; } }
}