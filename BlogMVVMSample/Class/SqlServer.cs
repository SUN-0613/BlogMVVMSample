using System;
using System.Data.SqlClient;

namespace BlogMVVMSample.Class
{

    /// <summary>SQL Server 接続管理</summary>
    public class SqlServer
    {

        #region ErrorProperty

        /// <summary>エラーメッセージ</summary>
        public string ExceptionMessage { get; private set; } = string.Empty;

        /// <summary>エラーが発生したか</summary>
        public bool IsError { get { return !string.IsNullOrEmpty(ExceptionMessage); } }

        #endregion

        #region SQL Server 接続情報

        /// <summary>接続インスタンス</summary>
        private SqlConnection _SqlConnection;

        /// <summary>接続FLG</summary>
        private bool _IsConnect = false;

        #endregion

        #region 新規作成、解放処理

        /// <summary>
        /// SQL Server 操作管理
        /// SQL Server認証による接続
        /// </summary>
        /// <param name="serverName">接続するサーバ名</param>
        /// <param name="dbName">データベース名称</param>
        /// <param name="userName">ユーザ名</param>
        /// <param name="password">パスワード</param>
        /// <param name="timeOut">タイムアウト(秒)</param>
        public SqlServer(string serverName, string dbName, string userName, string password, int timeOut = 30)
        {

            // SQL Serverに接続するための文字列作成
            using (var connectionString = new DisposableStringBuilder(256))
            {

                connectionString.Append("Data Source = ").Append(serverName).Append(";")
                                .Append("Initial Catalog = ").Append(dbName).Append(";")
                                .Append("User ID = ").Append(userName).Append(";")
                                .Append("Password = ").Append(password).Append(";")
                                .Append("MultipleActiveResultSets = True;")
                                .Append("Connection Timeout = ").Append(timeOut.ToString());

                // 接続開始
                Open(connectionString.ToString());

            }

        }

        /// <summary>
        /// SQL Server 操作管理
        /// Windows認証による接続
        /// </summary>
        /// <param name="serverName">接続するサーバ名</param>
        /// <param name="dbName">データベース名称</param>
        /// <param name="timeOut">タイムアウト(秒)</param>
        public SqlServer(string serverName, string dbName, int timeOut = 30)
        {

            // SQL Serverに接続するための文字列作成
            using (var connectionString = new DisposableStringBuilder(256))
            {

                connectionString.Append("Data Source = ").Append(serverName).Append(";")
                                .Append("Initial Catalog = ").Append(dbName).Append(";")
                                .Append("Integrated Security = True;")
                                .Append("MultipleActiveResultSets = True;")
                                .Append("Connection Timeout = ").Append(timeOut.ToString());

                // 接続開始
                Open(connectionString.ToString());

            }

        }

        /// <summary>エラー情報の初期化</summary>
        private void InitializeException()
        {

            if (!string.IsNullOrEmpty(ExceptionMessage))
            {
                ExceptionMessage = string.Empty;
            }

        }

        #endregion

        #region 接続、切断

        /// <summary>SQL Server接続</summary>
        /// <param name="connectionString">接続するためのパラメータ</param>
        private void Open(string connectionString)
        {

            try
            {

                // インスタンス生成
                _SqlConnection = new SqlConnection(connectionString);

                // SQL Server 接続
                _SqlConnection.Open();
                _IsConnect = true;

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        /// <summary>切断</summary>
        private void Close()
        {

            try
            {

                InitializeException();

                // 切断
                if (_IsConnect)
                {
                    _SqlConnection.Close();
                    _IsConnect = false;
                }

                // メモリ解放
                if (_SqlConnection != null)
                {
                    _SqlConnection.Dispose();
                    _SqlConnection = null;
                }

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        #endregion

    }

}
