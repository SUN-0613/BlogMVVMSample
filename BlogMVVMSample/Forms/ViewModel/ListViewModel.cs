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

        /// <summary>
        /// ファイル一覧で選択したファイル
        /// </summary>
        public FileInfo SelectedFile
        {
            get { return _Model.SelectedFile; }
            set
            {
                _Model.SelectedFile = value;
                CallPropertyChanged();
                CallPropertyChanged(nameof(FileInfo.Name));
                CallPropertyChanged(nameof(FileInfo.BitmapImage));
                CallPropertyChanged(nameof(FileInfo.LastWriteTime));
                CallPropertyChanged(nameof(FileInfo.Size));
                CallPropertyChanged(nameof(FileInfo.CreationTime));
            }
        }

        #endregion

    }
}
