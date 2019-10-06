using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;
using System.Data;

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

        /// <summary>選択しているデータベース・テーブル</summary>
        public DataBaseInfo SelectedItem
        {
            get { return _SelectedItem; }
            set
            {

                _SelectedItem = value;

                // 選択したテーブルのレコードを表示
                TableRecord = _Model.GetTableRecord(_SelectedItem);
                CallPropertyChanged(nameof(TableRecord));

            }
        }

        /// <summary>テーブルレコード</summary>
        public DataTable TableRecord { get; set; }

        #endregion

        /// <summary>選択しているデータベース・テーブル</summary>
        private DataBaseInfo _SelectedItem;

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
