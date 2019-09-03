using BlogMVVMSample.Data;
using System;
using System.Collections.ObjectModel;
using IO = System.IO;
using System.Threading.Tasks;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>
    /// Model
    /// </summary>
    public class ListModel
    {

        #region ViewModel.Property

        /// <summary>
        /// パス一覧
        /// </summary>
        public ObservableCollection<PathInfo> Paths;

        /// <summary>
        /// 選択パス
        /// </summary>
        public PathInfo SelectedPath
        {
            get { return _SelectedPath; }
            set
            {
                _SelectedPath = value;
                MakeFiles();
            }
        }

        /// <summary>
        /// 選択パス直下のファイル一覧
        /// </summary>
        public ObservableCollection<FileInfo> Files;

        /// <summary>
        /// ファイル一覧で選択したファイル
        /// </summary>
        public FileInfo SelectedFile;

        #endregion

        /// <summary>
        /// 選択パス
        /// </summary>
        private PathInfo _SelectedPath;

        /// <summary>
        /// Model
        /// </summary>
        public ListModel()
        {
            MakeDriveList();
        }

        /// <summary>
        /// ドライブ一覧取得
        /// </summary>
        private async void MakeDriveList()
        {

            Paths = new ObservableCollection<PathInfo>();

            await Task.Run(() => 
            {

                try
                {

                    foreach (var drive in Environment.GetLogicalDrives())
                    {
                        Paths.Add(new PathInfo(drive));
                    }

                }
                catch { }

            });

        }

        /// <summary>
        /// 選択パス直下のファイル一覧を取得
        /// </summary>
        private void MakeFiles()
        {

            if (Files == null)
            {
                Files = new ObservableCollection<FileInfo>();
            }
            else
            {
                Files.Clear();
            }

            if (IO::Directory.Exists(SelectedPath.FullPath))
            {

                try
                {

                    foreach (var filePath in IO::Directory.EnumerateFiles(SelectedPath.FullPath, "*", IO::SearchOption.TopDirectoryOnly))
                    {
                        Files.Add(new FileInfo(filePath));
                    }

                }
                catch { }

            }

        }

    }
}
