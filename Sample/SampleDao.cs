using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Natto;

public class SampleDao : ActiveRecord<SampleDao>
{
    public override string tableName { get { return "SampleTable"; } }

    public int param_int { get { return GetInt("param_int"); } set { SetInt("param_int", value); } }
    public string param_string { get { return GetString("param_string"); } set { SetString("param_string", value); } }
    public bool param_bool { get { return GetBool("param_bool"); } set { SetBool("param_bool", value); } }
}