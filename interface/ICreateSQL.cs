using System.Collections;

/// <summary>
/// DBを書き換えるSQL文を実装するインタフェース
/// </summary>
public interface ICreateSQL {
    string UpdateSQL();
    string CreateSQL();
}