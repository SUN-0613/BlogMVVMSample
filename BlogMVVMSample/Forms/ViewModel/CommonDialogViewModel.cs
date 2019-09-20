using BlogMVVMSample.MVVM;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>WindowsAPICodePackダイアログ表示.ViewModel</summary>
    public class CommonDialogViewModel : ViewModelBase
    {

        #region Model

        /// <summary>Model</summary>
        private Model.CommonDialogModel _Model;

        #endregion

        #region Property

        /// <summary>ファイル・フォルダを選択するダイアログ</summary>
        public CommonOpenFileDialog OpenDialog { get; set; }

        /// <summary>ファイルを保存するダイアログ</summary>
        public CommonSaveFileDialog SaveDialog { get; set; }

        /// <summary>ダイアログの処理結果</summary>
        public CommonFileDialogResult DialogResult { get; set; }

        /// <summary>ダイアログ表示コマンド</summary>
        public DelegateCommand<string> DialogCommand { get; private set; }

        /// <summary>選択されたファイル一覧</summary>
        public ObservableCollection<string> Files { get; set; }

        #endregion

        /// <summary>WindowsAPICodePackダイアログ表示.ViewModel</summary>
        public CommonDialogViewModel()
        {

            _Model = new Model.CommonDialogModel();

            DialogCommand = new DelegateCommand<string>(
                (parameter) => 
                {

                    switch (parameter)
                    {

                        case "openFile":    // ファイルを選択

                            OpenDialog = new CommonOpenFileDialog()
                            {
                                Title = "ファイルを選択してください",
                                IsFolderPicker = false,                             // フォルダ選択
                                DefaultDirectory = Environment.CurrentDirectory,    // 初期表示フォルダ
                                Multiselect = true                                  // 複数選択
                            };

                            // 拡張子フィルタ
                            OpenDialog.Filters.Add(new CommonFileDialogFilter("全てのファイル", "*.*"));

                            CallPropertyChanged(nameof(OpenDialog));

                            if (DialogResult.Equals(CommonFileDialogResult.Ok))
                            {

                                Files.Clear();
                                Files = _Model.GetFiles(OpenDialog.FileNames);

                                CallPropertyChanged(nameof(Files));

                            }

                            break;

                        case "openFolder":  // フォルダを選択

                            OpenDialog = new CommonOpenFileDialog()
                            {
                                Title = "フォルダを選択してください",
                                IsFolderPicker = true,                              // フォルダ選択
                                DefaultDirectory = Environment.CurrentDirectory,    // 初期表示フォルダ
                                Multiselect = false                                 // 複数選択
                            };

                            CallPropertyChanged(nameof(OpenDialog));

                            if (DialogResult.Equals(CommonFileDialogResult.Ok))
                            {

                                Files.Clear();
                                Files = _Model.GetFiles(OpenDialog.FileName);

                                CallPropertyChanged(nameof(Files));

                            }

                            break;

                        case "saveFile":    // ファイルを保存

                            SaveDialog = new CommonSaveFileDialog()
                            {
                                Title = "保存するファイル名を入力してください",
                                DefaultDirectory = Environment.CurrentDirectory,
                                DefaultFileName = "SaveFile.txt"
                            };

                            // 拡張子フィルタ
                            SaveDialog.Filters.Add(new CommonFileDialogFilter("全てのファイル", "*.*"));

                            CallPropertyChanged(nameof(SaveDialog));

                            if (DialogResult.Equals(CommonFileDialogResult.Ok))
                            {
                                _Model.SaveFile(SaveDialog.FileName);
                            }

                            break;

                        default:
                            break;

                    }

                },
                () => true);

            Files = new ObservableCollection<string>();

        }

    }

}
