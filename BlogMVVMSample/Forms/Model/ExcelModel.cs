using BlogMVVMSample.Data;
using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>Excel読込Model</summary>
    public class ExcelModel
    {

        /// <summary>選択されたファイル一覧からExcelファイルを取得</summary>
        /// <param name="SelectedPaths">選択されたファイル一覧</param>
        /// <returns>Excelファイルパス</returns>
        public string GetExcelFile(IList selectedPaths)
        {

            foreach (var obj in selectedPaths)
            {

                if (obj is string path)
                {

                    // 拡張子がExcelファイル：.xlsx、.xlsmであるか
                    switch (Path.GetExtension(path).ToUpper())
                    {

                        case ".XLSX":
                        case ".XLSM":
                            return path;

                    }

                }

            }

            // 該当なし
            return "";

        }

        /// <summary>Excelファイル読み込み</summary>
        /// <param name="fullPath">Excelファイルのフルパス</param>
        /// <returns>住所一覧</returns>
        /// <remarks>
        /// Copyright(c) 2016 ClosedXML
        /// Released under the MIT license
        /// https://github.com/ClosedXML/ClosedXML/blob/master/LICENSE
        /// </remarks>
        public ObservableCollection<Address> ReadExcelFile(string fullPath)
        {

            var collection = new ObservableCollection<Address>();

            try
            {

                // 引数のパスにファイルが存在するか
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException("ファイルが見つかりません");
                }

                // Excelファイルオープン
                using (var workbook = new XLWorkbook(fullPath))
                {

                    // Excelの先頭ワークシートを指定
                    var worksheet = workbook.Worksheet(1);

                    // 該当ワークシート内でデータが入力されている最終行
                    var lastRow = worksheet.LastRowUsed().RowNumber();

                    // 該当ワークシート内でデータが入力されている最終列
                    var lastColumn = worksheet.LastColumnUsed().ColumnNumber();

                    // 最終行まで繰り返す
                    for (var i = 1; i <= lastRow; i++)
                    {

                        // 列数が足りているか
                        if (lastColumn >= 4)
                        {

                            // 住所一覧に登録
                            collection.Add(new Address()
                            {
                                // セル2Aを参照する時はCell(2, 1)と指定
                                PostalCode = worksheet.Cell(i, 1).Value.ToString(),
                                Prefectures = worksheet.Cell(i, 2).Value.ToString(),
                                City = worksheet.Cell(i, 3).Value.ToString(),
                                Place = worksheet.Cell(i, 4).Value.ToString()
                            });

                        }

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