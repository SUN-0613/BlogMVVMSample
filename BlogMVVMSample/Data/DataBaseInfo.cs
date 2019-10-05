using System.Collections.ObjectModel;

namespace BlogMVVMSample.Data
{

    /// <summary>データベース情報</summary>
    public class DataBaseInfo
    {

        #region Property

        /// <summary>データベース・テーブル名称</summary>
        public string Name { get; set; }

        /// <summary>自身がテーブルの場合、所属するデータベース</summary>
        public string ParentName { get; set; } = string.Empty;

        /// <summary>テーブル一覧</summary>
        public ObservableCollection<DataBaseInfo> Tables { get; set; }

        #endregion

        /// <summary>データベース情報</summary>
        public DataBaseInfo()
        {
            Tables = new ObservableCollection<DataBaseInfo>();
        }

    }

}
