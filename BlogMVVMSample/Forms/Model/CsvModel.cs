using BlogMVVMSample.Data;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>CSV読込Model</summary>
    public class CsvModel
    {

        /// <summary>選択されたファイル一覧からCSVファイルを取得</summary>
        /// <param name="SelectedPaths">選択されたファイル一覧</param>
        /// <returns>CSVファイルパス</returns>
        public string GetCsvFile(IList SelectedPaths)
        {

            foreach (var obj in SelectedPaths)
            {

                if (obj is string path)
                {

                    if (Path.GetExtension(path).ToUpper().Equals(".CSV"))
                    {
                        return path;
                    }

                }

            }

            return "";

        }

        /// <summary>CSVファイル読み込み</summary>
        /// <param name="fullPath">CSVファイルのフルパス</param>
        /// <returns>住所一覧</returns>
        public ObservableCollection<Address> ReadCsvFile(string fullPath)
        {

            var collection = new ObservableCollection<Address>();

            try
            {

                // 引数のパスにファイルが存在するか
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException("ファイルが見つかりません");
                }

                // 行データをカンマ区切りで分割するようにファイルオープン
                using (var parser = new TextFieldParser(fullPath, Encoding.Default) { Delimiters = new string[] { "," } })
                {

                    // 最終行まで繰り返す
                    while (!parser.EndOfData)
                    {

                        // 文字列中の前後スペースを削除しない
                        parser.TrimWhiteSpace = false;

                        // カンマで分割した文字列の配列を取得
                        var cells = parser.ReadFields();

                        // 住所一覧に登録
                        collection.Add(new Address()
                        {
                            PostalCode = cells[0],
                            Prefectures = cells[1],
                            City = cells[2],
                            Place = cells[3]
                        });

                    }

                }

            }
            catch (Exception ex)
            {

                // エラー内容を出力
                Debug.WriteLine(ex.Message);

            }

            return collection;

        }

    }

}
