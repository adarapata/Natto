using UnityEngine;
using System.Collections;
using Natto;

public class NattoSample : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
        SampleDao dao = SampleDao.Find (n => n.param_string == "okame");
        print (dao.param_string);

        SampleDao.Where (n => n.param_int > 60).ForEach (n => print (n.param_string_null));
    }

    // Update is called once per frame
    void Update ()
    {
    }
}
