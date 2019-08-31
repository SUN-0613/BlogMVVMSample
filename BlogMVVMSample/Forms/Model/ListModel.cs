using BlogMVVMSample.Data;
using System;
using System.Collections.ObjectModel;
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
        public PathInfo SelectedPath;

        #endregion

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

    }
}
