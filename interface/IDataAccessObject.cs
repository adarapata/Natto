using System.Collections;
using System.Collections.Generic;

namespace Natto.Interface {
    /// <summary>
    /// DBの情報をオブジェクトにマッピングするインタフェース
    /// </summary>
    public interface IDataAccessObject
    {
        string tableName { get; }
        int id { get; }
        void Mapping(Dictionary<string, object> colomn);
    }
}