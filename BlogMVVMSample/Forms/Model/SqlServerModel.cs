using BlogMVVMSample.Class;
using BlogMVVMSample.Data;
using BlogMVVMSample.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>SQL Serverクラス使用サンプル.Model</summary>
    public class SqlServerModel
    {

        /// <summary>データベース情報一覧の取得</summary>
        /// <returns>データベース情報一覧</returns>
        public ObservableCollection<DataBaseInfo> GetDataBaseInfo()
        {

            try
            {

                // 戻り値の宣言
                var values = new ObservableCollection<DataBaseInfo>();

                // Windows認証でDB接続
                using (var sqlServer = new SqlServer(Settings.Default.ServerName, Settings.Default.DbName))
                {

                    // 接続エラー確認
                    if (sqlServer.IsError)
                    {
                        throw new Exception(sqlServer.ExceptionMessage);
                    }

                    // クエリを保存するStringBuilderの宣言
                    using (var query = new DisposableStringBuilder())
                    {

                        // データベース一覧取得クエリの作成
                        query.Append(@"SELECT name FROM sys.databases ORDER BY database_id");

                        // クエリを実行してSystem.Data.SqlClient.SqlDataReaderで取得
                        using (var dataReader = sqlServer.ExecuteQuery(query.ToString()))
                        {

                            // 実行エラー確認
                            if (sqlServer.IsError)
                            {
                                throw new Exception(sqlServer.ExceptionMessage);
                            }

                            // データ呼び出し
                            while (dataReader.Read())
                            {
                                values.Add(new DataBaseInfo() { Name = dataReader.GetString(0) });
                            }

                        }

                        // パラメータの宣言
                        var parameter = new Dictionary<string, object>();

                        // データベース毎にテーブル一覧を取得
                        for (var i = 0; i < values.Count; i++)
                        {

                            // テーブル一覧を取得するクエリの作成
                            // ユーザテーブルのみを対象とする
                            query.Clear();
                            query.Append(@"USE ");
                            query.Append(values[i].Name);
                            query.Append(@" SELECT name FROM sys.objects WHERE type = @Type");

                            // パラメータの作成
                            parameter.Clear();
                            parameter.Add(@"@Type", "U");

                            // クエリを実行してSystem.Data.SqlClient.SqlDataReaderで取得
                            using (var dataReader = sqlServer.ExecuteQuery(query.ToString(), parameter))
                            {

                                // 実行エラー確認
                                if (sqlServer.IsError)
                                {
                                    throw new Exception(sqlServer.ExceptionMessage);
                                }

                                // データ呼び出し
                                while (dataReader.Read())
                                {
                                    values[i].Tables.Add(new DataBaseInfo()
                                    {
                                        Name = dataReader.GetString(0),
                                        ParentName = values[i].Name
                                    });
                                }

                            }

                        }

                    }

                }

                return values;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;

        }

    }

}
