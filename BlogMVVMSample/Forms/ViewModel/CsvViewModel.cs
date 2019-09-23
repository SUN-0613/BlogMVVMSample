using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>CSV読込ViewModel</summary>
    public class CsvViewModel : ViewModelBase
    {

        #region Model

        /// <summary>CSV読込Model</summary>
        private Model.CsvModel _Model = new Model.CsvModel();

        #endregion

        #region Property

        /// <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        public IList DragAndDropPaths
        {
            get { return _DragAndDropPaths; }
            set
            {

                _DragAndDropPaths = value;
                FilePath = _Model.GetCsvFile(_DragAndDropPaths);

            }
        }

        /// <summary>ファイルを選択するダイアログ</summary>
        public CommonOpenFileDialog OpenDialog { get; set; }

        /// <summary>ダイアログの処理結果</summary>
        public CommonFileDialogResult DialogResult { get; set; }

        /// <summary>ダイアログ表示コマンド</summary>
        public DelegateCommand DialogCommand { get; private set; }

        /// <summary>ファイルパス</summary>
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                if (File.Exists(value))
                {

                    _FilePath = value;
                    CallPropertyChanged();

                    Addresses = _Model.ReadCsvFile(_FilePath);
                    CallPropertyChanged(nameof(Addresses));

                }
            }
        }

        /// <summary>住所一覧</summary>
        public ObservableCollection<Address> Addresses { get; set; }

        #region CSVファイルの作成

        /// <summary>ファイルを保存するダイアログ</summary>
        public CommonSaveFileDialog SaveDialog { get; set; }

        /// <summary>保存ダイアログ表示コマンド</summary>
        public DelegateCommand SaveDialogCommand { get; private set; }

        #endregion

        #endregion

        /// <summary>ファイルパス</summary>
        private string _FilePath;

        /// <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        private IList _DragAndDropPaths;

        /// <summary>CSV読込ViewModel</summary>
        public CsvViewModel()
        {

            DialogCommand = new DelegateCommand(
                () => 
                {
                    OpenDialog = new CommonOpenFileDialog()
                    {
                        Title = "CSVファイルを選択してください",
                        IsFolderPicker = false,                             // フォルダ選択
                        DefaultDirectory = Environment.CurrentDirectory,    // 初期表示フォルダ
                        Multiselect = false                                 // 複数選択
                    };

                    // 拡張子フィルタ
                    OpenDialog.Filters.Add(new CommonFileDialogFilter("CSVファイル", "*.csv"));

                    CallPropertyChanged(nameof(OpenDialog));

                    if (DialogResult.Equals(CommonFileDialogResult.Ok))
                    {
                        FilePath = OpenDialog.FileName;
                    }

                },
                () => true);

            #region CSVファイルの作成

            SaveDialogCommand = new DelegateCommand(
                () => 
                {

                    using (SaveDialog = new CommonSaveFileDialog()
                    {
                        Title = "保存するファイル名を入力してください",
                        DefaultDirectory = Environment.CurrentDirectory,
                        DefaultFileName = "SaveFile.csv"
                    })
                    {

                        // 拡張子フィルタ
                        SaveDialog.Filters.Add(new CommonFileDialogFilter("CSVファイル", "*.csv"));

                        CallPropertyChanged(nameof(SaveDialog));

                        if (DialogResult.Equals(CommonFileDialogResult.Ok))
                        {
                            _Model.SaveCsvFile(SaveDialog.FileName, Addresses);
                        }

                    }

                }, 
                () => true);

            #endregion

        }

    }

}
