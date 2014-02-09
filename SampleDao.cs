using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using ActiveRecord;

public class SampleDao : AcitiveRecord<SampleDao>, IDataAccessObject, ICreateSQL, IDeleteSQL
{
    public string tableName { get { return "SampleTable"; } }
    public bool deleteFlag { get; set; }
    public int id { get; set; }

    public int param_int { get; set; }
    public string param_string { get; set; }
    public bool param_bool { get; set; }

    public void Mapping(Dictionary<string, object> parameters)
    {
        id = Convert.ToInt16(parameters["id"]);
        param_int = Convert.ToInt16(parameters["param_int"]);
        param_string = (string)parameters["param_string"];
        param_bool = Convert.ToBoolean(parameters["param_bool"]);
    }

    public string CreateSQL()
    {
        string colomn = "(param_int, param_string)";
        string values = " VALUES(" + param_int.ToString()
                        + ',' + param_string + ");";
        return colomn + values;
    }

    public string UpdateSQL()
    {
        string update = "param_int = " + param_int.ToString()
                       + ", param_string = " + param_string
                       + ", param_bool = " + param_bool.ToString()
                       + " WHERE id = " + id.ToString() + ";";
        return update;
    }
}