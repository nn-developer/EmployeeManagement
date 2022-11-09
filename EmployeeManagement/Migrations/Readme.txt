パッケージマネージャコンソールコマンド
参考：https://learn.microsoft.com/ja-jp/ef/core/cli/powershell

Enable-Migrations
Configurationクラスを作成してマイグレーション実行可能にする

Add-Migration <マイグレーション名>
DBファイルとDbMigrationクラス（<timestamp>_<マイグレーション名>.cs）を作成
ex)
Add-Migration InitialMigration

Update-Database <マイグレーション名>※省略可
データベースを最後の移行または指定された移行に更新
ex)
Update-Database -Verbose
Update-Database InitialMigration -Verbose