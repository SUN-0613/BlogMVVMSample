using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class TextBoxViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// TextBoxに表示する文字列のプロパティ
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ボタンクリック処理コマンドプロパティ
        /// </summary>
        public DelegateCommand ButtonClickCommand { get; }

        #endregion

        /// <summary>
        /// ViewModel
        /// </summary>
        public TextBoxViewModel()
        {

            // コマンドの設定
            ButtonClickCommand = new DelegateCommand(
                () => { InputTextBox(); },  // 実行メソッド
                () => { return true; }      // 実行メソッド許可
                );

        }

        /// <summary>
        /// TextBoxにHello World!を表示
        /// </summary>
        public void InputTextBox()
        {

            Text = "Hello World!";
            CallPropertyChanged(nameof(Text));

        }

    }

}
