using System;
using IO = System.IO;

namespace BlogMVVMSample.Data
{

    /// <summary>
    /// ファイル情報
    /// </summary>
    public class FileInfo
    {

        #region Property

        /// <summary>
        /// ファイル名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ファイルサイズ
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreationTime { get; set; }

        #endregion

        /// <summary>
        /// フルパス
        /// </summary>
        public string FullPath;

        /// <summary>
        /// ファイル情報
        /// </summary>
        /// <param name="fullPath">フルパス</param>
        public FileInfo(string fullPath)
        {

            FullPath = fullPath;

            if (IO::File.Exists(FullPath))
            {

                var fileInfo = new IO::FileInfo(FullPath);

                Name = fileInfo.Name;
                Size = fileInfo.Length;
                CreationTime = fileInfo.CreationTime;

            }

        }

    }

}
