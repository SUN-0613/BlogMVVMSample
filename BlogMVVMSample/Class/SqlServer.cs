using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlogMVVMSample.Class
{

    /// <summary>SQL Server 接続管理</summary>
    public class SqlServer : IDisposable
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

        /// <summary>トランザクション</summary>
        private SqlTransaction _SqlTransaction;

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

        /// <summary>解放処理</summary>
        public void Dispose()
        {

            // トランザクションの途中ならロールバック
            Rollback();

            // 切断
            Close();

        }

        /// <summary>エラー情報の初期化</summary>
        /// <param name="checkConnect">SQL Serverに接続済みかチェックする</param>
        private void InitializeException(bool checkConnect = true)
        {

            if (!string.IsNullOrEmpty(ExceptionMessage))
            {
                ExceptionMessage = string.Empty;
            }

            if (checkConnect)
            {
                CheckConnect();
            }

        }

        /// <summary>SQL Serverに接続済かチェックする</summary>
        private void CheckConnect()
        {
            if (!_IsConnect)
            {
                throw new BadImageFormatException("Can not connect to SQL Server");
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

                // トランザクション初期化
                if (_SqlTransaction != null)
                {
                    _SqlTransaction.Dispose();
                    _SqlTransaction = null;
                }

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        #endregion

        #region トランザクション

        /// <summary>トランザクション開始</summary>
        public void BeginTransaction()
        {

            try
            {

                InitializeException();

                _SqlTransaction = _SqlConnection.BeginTransaction();

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        /// <summary>コミット</summary>
        public void Commit()
        {

            try
            {

                InitializeException();

                if (_SqlTransaction.Connection != null)
                {
                    _SqlTransaction.Commit();
                    _SqlTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        /// <summary>ロールバック</summary>
        public void Rollback()
        {

            try
            {

                InitializeException();

                if (_SqlTransaction.Connection != null)
                {
                    _SqlTransaction.Rollback();
                    _SqlTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }

        }

        #endregion

        #region クエリ実行

        /// <summary>クエリ実行</summary>
        /// <param name="query">SQL文</param>
        /// <param name="parameters">SQLパラメータ</param>
        /// <param name="queryTimeout">クエリ実行時間(秒)</param>
        /// <returns>クエリ実行結果</returns>
        public SqlDataReader ExecuteQuery(string query, Dictionary<string, object> parameters, int queryTimeout = 30)
        {

            try
            {

                // エラーメッセージの初期化
                InitializeException();

                using (var sqlCommand = new SqlCommand(query, _SqlConnection, _SqlTransaction))
                {

                    // タイムアウトの設定
                    sqlCommand.CommandTimeout = queryTimeout;

                    // パラメータの設定
                    foreach (var parameter in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    // 実行
                    return sqlCommand.ExecuteReader();

                }

            }
            catch (Exception ex)
            {

                ExceptionMessage = ex.Message;
                return null;

            }

        }

        /// <summary>クエリ実行</summary>
        /// <param name="query">SQL文</param>
        /// <param name="queryTimeout">クエリ実行時間(秒)</param>
        /// <returns>クエリ実行結果</returns>
        public SqlDataReader ExecuteQuery(string query, int queryTimeout = 30)
        {
            return ExecuteQuery(query, new Dictionary<string, object>(), queryTimeout);
        }

        /// <summary>クエリ実行</summary>
        /// <param name="query">SQL文</param>
        /// <param name="parameters">SQLパラメータ</param>
        /// <param name="queryTimeout">クエリ実行時間(秒)</param>
        /// <returns>更新された行数</returns>
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters, int queryTimeout = 30)
        {

            try
            {

                InitializeException();

                using (var sqlCommand = new SqlCommand(query, _SqlConnection, _SqlTransaction))
                {

                    // タイムアウトの設定
                    sqlCommand.CommandTimeout = queryTimeout;

                    // パラメータの設定
                    foreach (var parameter in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    // 実行
                    return sqlCommand.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {

                ExceptionMessage = ex.Message;
                return -1;

            }

        }

        /// <summary>クエリ実行後、DataTableにて返す</summary>
        /// <param name="query">SQL文</param>
        /// <param name="parameters">SQLパラメータ</param>
        /// <param name="queryTimeout">クエリ実行時間(秒)</param>
        /// <returns>クエリ実行結果</returns>
        public DataTable ExecuteQueryToDataTable(string query, Dictionary<string, object> parameters, int queryTimeout = 30)
        {

            try
            {

                InitializeException();

                using (var sqlCommand = new SqlCommand(query, _SqlConnection, _SqlTransaction))
                {

                    // タイムアウトの設定
                    sqlCommand.CommandTimeout = queryTimeout;

                    // パラメータの設定
                    foreach (var parameter in parameters)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    // 実行
                    sqlCommand.ExecuteNonQuery();

                    // 戻り値作成
                    var readData = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter(sqlCommand))
                    {

                        dataAdapter.Fill(readData);

                    }

                    return readData;

                }

            }
            catch (Exception ex)
            {

                ExceptionMessage = ex.Message;
                return null;

            }

        }

        /// <summary>クエリ実行後、DataTableにて返す</summary>
        /// <param name="query">SQL文</param>
        /// <param name="queryTimeout">クエリ実行時間(秒)</param>
        /// <returns>クエリ実行結果</returns>
        public DataTable ExecuteQueryToDataTable(string query, int queryTimeout = 30)
        {
            return ExecuteQueryToDataTable(query, new Dictionary<string, object>(), queryTimeout);
        }

        #endregion

    }

}
