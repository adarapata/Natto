# Natto

![Natto](https://f.cloud.github.com/assets/1734002/2138617/e53e9804-9335-11e3-8154-213926b76690.jpg)

=======================

Unityで使える簡易的ORマッパー

## インストール

1. Unityプロジェクト内の任意の場所にclone `git@github.com:adarapata/Natto.git`

2. `Assets/StreamingAssets/` 下にdbファイルを配置する(SQLiteの場合)

3. `DbNameCarrier` をオブジェクトにアタッチする

4. 対応したDaoクラスを作成する。[サンプル](https://github.com/adarapata/Natto/blob/master/Sample/SampleDao.cs)

## 使い方

### 全部取得
```C#
DaoClass.FindAll(); // => List<DaoClass>
```

### 一つ取得(条件付)
```C#
DaoClass.Find(n => n.id == 2); // => DaoClass
```

### 複数取得(条件付)
```C#
DaoClass.Where(n => n.hoge == "hoge"); // => List<DaoClass>
```

### 新規レコード追加
```C#
DaoClass dao = new DaoClass { foo = "foo", bar = "bar" };
DaoClass.Create(dao); // => Void
```

### レコード更新
```C#
DaoClass dao = DaoClass.Find(n => n.id == 2);
dao.foo = "foo2";
DaoClass.Update(dao); // => Void
```

### レコード削除
```C#
DaoClass dao = DaoClass.Find(n => n.id == 2);
DaoClass.Delete(dao); // => Void
```

※ 現在、sqlite(パスワード無し)、MySQL 5.6.14 の動作確認をしています。


制作にあたり、下記の資料を参考にさせていただきました。

https://sites.google.com/site/nrapmed/unityrepo/unisqlite

http://terasur.blog.fc2.com/blog-entry-265.html

http://qiita.com/oishihiroaki/items/6eb9732efb44d4986428
