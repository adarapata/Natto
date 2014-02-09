Natto
=======================

Unityで使える簡易的なActiveRecordもどき

## 使い方

1. Unityプロジェクト内の任意の場所にclone `git clone git@github.com:adarapata/Easy-ActiveRecord-Unity.git`

2. `Assets/StreamingAssets/` 下にdbファイルを配置する

3. `DbNameCarrier` をオブジェクトにアタッチして、dbnameを任意の名前に変更する

4. 対応したDaoクラスを作成する。[サンプル](https://github.com/adarapata/Easy-ActiveRecord-Unity/blob/master/SampleDao.cs)

※ 現在、sqlite(パスワード無し) のみ動作確認しています。


制作にあたり、下記の資料を参考にさせていただきました。

https://sites.google.com/site/nrapmed/unityrepo/unisqlite
http://terasur.blog.fc2.com/blog-entry-265.html
