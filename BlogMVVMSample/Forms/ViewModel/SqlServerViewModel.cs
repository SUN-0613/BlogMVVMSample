using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>SQL Serverクラス使用サンプル.ViewModel</summary>
    public class SqlServerViewModel : ViewModelBase
    {

        #region Model

        /// <summary>SQL Serverクラス使用サンプル.Model</summary>
        private Model.SqlServerModel _Model;

        #endregion

        #region Property

        /// <summary>データベース・テーブル一覧</summary>
        public ObservableCollection<DataBaseInfo> DataBaseInfoList { get; set; }

        #endregion

        /// <summary>SQL Serverクラス使用サンプル.ViewModel</summary>
        public SqlServerViewModel()
        {

            _Model = new Model.SqlServerModel();

            // データベース・テーブル一覧の取得
            DataBaseInfoList = _Model.GetDataBaseInfo();
            CallPropertyChanged(nameof(DataBaseInfoList));

        }

    }

}
