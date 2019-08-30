using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace BlogMVVMSample.Data
{

    /// <summary>
    /// パス情報
    /// </summary>
    public class PathInfo
    {

        #region Property

        /// <summary>
        /// フルパス
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// パス名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子階層
        /// </summary>
        public ObservableCollection<PathInfo> Children { get; set; }

        #endregion

        /// <summary>
        /// パス情報
        /// </summary>
        /// <param name="fullPath">フルパス</param>
        public PathInfo(string fullPath)
        {

            FullPath = fullPath;

            Name = Path.GetFileName(fullPath);

            // ドライブ名は上記で取得できないので再設定
            if (Name.Length.Equals(0))
            {
                Name = FullPath;
            }

            MakeChildren();

        }

        /// <summary>
        /// 子階層のパス一覧を取得
        /// </summary>
        private async void MakeChildren()
        {

            Children = new ObservableCollection<PathInfo>();

            await Task.Run(() =>
            {

                try
                {

                    if (Directory.Exists(FullPath))
                    {

                        // 下位のフォルダ一覧を取得
                        foreach (var path in Directory.EnumerateDirectories(FullPath, "*", SearchOption.TopDirectoryOnly))
                        {
                            Children.Add(new PathInfo(path));
                        }

                        // 下位のファイル一覧を取得
                        foreach (var file in Directory.EnumerateFiles(FullPath, "*", SearchOption.TopDirectoryOnly))
                        {
                            Children.Add(new PathInfo(file));
                        }

                    }

                }
                catch { }

            });

        }

    }
}
