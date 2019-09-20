using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>WindowsAPICodePackダイアログ表示.Model</summary>
    public class CommonDialogModel
    {

        /// <summary>ダイアログで取得したファイル一覧をObservableCollection()にセット</summary>
        /// <param name="files">ダイアログで取得したファイル一覧</param>
        /// <returns>ObservableCollection()にセットしたファイル一覧</returns>
        public ObservableCollection<string> GetFiles(IEnumerable<string> files)
        {

            var returnValues = new ObservableCollection<string>();

            foreach (var file in files)
            {
                returnValues.Add(file);
            }

            return returnValues;

        }

        /// <summary>ダイアログで取得したフォルダ直下のファイル一覧をObservableCollection()にセット</summary>
        /// <param name="folder">ダイアログで取得したフォルダ</param>
        /// <returns>ObservableCollection()にセットしたファイル一覧</returns>
        public ObservableCollection<string> GetFiles(string folder)
        {

            var returnValues = new ObservableCollection<string>();

            if (Directory.Exists(folder))
            {

                try
                {

                    foreach (var file in Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly))
                    {
                        returnValues.Add(file);
                    }

                }
                catch { }

            }

            return returnValues;

        }

        /// <summary>ダイアログで指定したファイルを空データで作成</summary>
        /// <param name="file">ダイアログで指定したファイル</param>
        public void SaveFile(string file)
        {

            using (var fs = File.Create(file))
            { }

        }

    }
}
