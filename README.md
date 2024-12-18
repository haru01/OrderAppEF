## これは？
EFの動きをログで確認する学習用

### 必要パッケージのインストール
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
### マイグレーションファイルの生成

```
dotnet ef migrations add InitialCreate
```

### データベース作成とテーブルの確認

```
dotnet ef database update
```
```
sqlite3 orderapp.db
```
```
.tables
```

### サンプル実行（Program.cs）
```
dotnet run
```
