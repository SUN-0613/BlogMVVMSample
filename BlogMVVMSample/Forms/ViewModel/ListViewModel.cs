using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class ListViewModel : ViewModelBase
    {

        #region Model

        private Model.ListModel _Model = new Model.ListModel();

        #endregion

        #region Property

        /// <summary>
        /// パス一覧
        /// </summary>
        public ObservableCollection<PathInfo> Paths
        {
            get { return _Model.Paths; }
            set { _Model.Paths = value; }
        }

        /// <summary>
        /// 選択パス
        /// </summary>
        public PathInfo SelectedPath
        {
            get { return _Model.SelectedPath; }
            set
            {
                _Model.SelectedPath = value;
                CallPropertyChanged();
                CallPropertyChanged(nameof(FullPath));
                CallPropertyChanged(nameof(Files));
            }
        }

        /// <summary>
        /// 選択パスのフルパス
        /// </summary>
        public string FullPath {  get { return _Model.SelectedPath.FullPath; } }

        /// <summary>
        /// 選択パス直下のファイル一覧
        /// </summary>
        public ObservableCollection<FileInfo> Files
        {
            get { return _Model.Files; }
            set { _Model.Files = value; }
        }

        #endregion

    }
}
