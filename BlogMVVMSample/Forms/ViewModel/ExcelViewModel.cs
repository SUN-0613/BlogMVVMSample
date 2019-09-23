using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>Excel読込ViewModel</summary>
    public class ExcelViewModel : ViewModelBase
    {

        #region Model

        /// <summary>Excel読込Model</summary>
        private Model.ExcelModel _Model = new Model.ExcelModel();

        #endregion

        #region Property

        /// <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        public IList DragAndDropPaths
        {
            get { return _DragAndDropPaths; }
            set
            {

                _DragAndDropPaths = value;
                FilePath = _Model.GetExcelFile(_DragAndDropPaths);

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

                    Addresses = _Model.ReadExcelFile(_FilePath);
                    CallPropertyChanged(nameof(Addresses));

                }
            }
        }

        /// <summary>住所一覧</summary>
        public ObservableCollection<Address> Addresses { get; set; }

        #endregion

        /// <summary>ファイルパス</summary>
        private string _FilePath;

        /// <summary>ドラッグ＆ドロップで選択されたファイル一覧</summary>
        private IList _DragAndDropPaths;

        /// <summary>Excel読込ViewModel</summary>
        public ExcelViewModel()
        {

            DialogCommand = new DelegateCommand(
                () =>
                {
                    OpenDialog = new CommonOpenFileDialog()
                    {
                        Title = "Excelファイルを選択してください",
                        IsFolderPicker = false,                             // フォルダ選択
                        DefaultDirectory = Environment.CurrentDirectory,    // 初期表示フォルダ
                        Multiselect = false                                 // 複数選択
                    };

                    // 拡張子フィルタ
                    OpenDialog.Filters.Add(new CommonFileDialogFilter("Excelファイル", "*.xlsx;*.xlsm"));

                    CallPropertyChanged(nameof(OpenDialog));

                    if (DialogResult.Equals(CommonFileDialogResult.Ok))
                    {
                        FilePath = OpenDialog.FileName;
                    }

                },
                () => true);

        }

    }

}
