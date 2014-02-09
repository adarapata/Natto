using UnityEngine;
using System.Collections;

namespace ActiveRecord {
    public interface IDeleteSQL {
        bool deleteFlag { get; set; }
    }
}