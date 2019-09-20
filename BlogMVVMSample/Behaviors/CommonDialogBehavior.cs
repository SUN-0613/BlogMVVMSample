using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>ファイルを開くダイアログを表示するためのビヘイビア</summary>
    public class CommonDialogBehavior : TriggerAction<FrameworkElement>
    {

        #region DependencyProperty

        /// <summary>ダイアログの処理結果依存プロパティ</summary>
        public static readonly DependencyProperty ResultProperty
            = DependencyProperty.Register(
                nameof(Result)
                , typeof(CommonFileDialogResult)
                , typeof(CommonDialogBehavior)
                , new PropertyMetadata(CommonFileDialogResult.None)
                );

        #endregion

        #region Property

        /// <summary>ダイアログの処理結果プロパティ</summary>
        public CommonFileDialogResult Result
        {
            get { return (CommonFileDialogResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        #endregion

        /// <summary>ダイアログを表示</summary>
        /// <param name="parameter">パラメータ</param>
        protected override void Invoke(object parameter)
        {

            if (parameter is DependencyPropertyChangedEventArgs e)
            {

                if (e.NewValue is CommonOpenFileDialog openDialog)
                {

                    // ファイル・フォルダを開くダイアログ
                    Result = openDialog.ShowDialog();

                }
                else if (e.NewValue is CommonSaveFileDialog saveDialog)
                {

                    // ファイルを保存するダイアログ
                    Result = saveDialog.ShowDialog();

                }

            }

        }

    }

}
