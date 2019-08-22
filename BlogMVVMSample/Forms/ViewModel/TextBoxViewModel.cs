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

        #endregion

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
