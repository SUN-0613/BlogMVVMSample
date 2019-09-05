using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// メッセージボックス出力ViewModel
    /// </summary>
    public class MessageBoxViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// メッセージ表示コマンド
        /// </summary>
        public DelegateCommand MessageCommand { get; private set; }

        #endregion

        public MessageBoxViewModel()
        {

            // メッセージボックスを表示するためのプロパティ変更イベントを実行する
            MessageCommand = new DelegateCommand(() => { CallPropertyChanged("CallMessageBox"); }, () => true);

        }

    }

}
