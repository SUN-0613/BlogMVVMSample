using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Windows;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ビヘイビアを使ってメッセージボックス出力.ViewModel
    /// </summary>
    public class MessageBox2ViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// メッセージ表示コマンド
        /// </summary>
        public DelegateCommand MessageCommand { get; private set; }

        /// <summary>
        /// メッセージボックス表示内容
        /// </summary>
        public MessageBoxInfo MessageInfo
        {
            get { return _MessageInfo; }
            private set
            {
                _MessageInfo = value;
                CallPropertyChanged();
            }
        }

        /// <summary>
        /// メッセージボックスの結果を表示
        /// </summary>
        public string MessageBoxResult { get; set; }

        #endregion

        /// <summary>
        /// メッセージボックス表示内容
        /// </summary>
        private MessageBoxInfo _MessageInfo;

        public MessageBox2ViewModel()
        {

            // メッセージボックスを表示するためのプロパティ変更イベントを実行する
            MessageCommand = new DelegateCommand(
                () =>
                {
                    MessageInfo = new MessageBoxInfo()
                    {
                        Message = "Hello World!",
                        Title = "MessageBoxView",
                        Button = MessageBoxButton.YesNo,
                        Image = MessageBoxImage.Information
                    };

                    MessageBoxResult = MessageInfo.Result.ToString();
                    CallPropertyChanged(nameof(MessageBoxResult));

                },
                () => true);

        }

    }

}
