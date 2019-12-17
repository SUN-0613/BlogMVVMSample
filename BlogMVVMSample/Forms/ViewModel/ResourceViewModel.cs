using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using BlogMVVMSample.Properties;
using System.Globalization;
using System.Threading;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>リソースファイルによる表示言語切替.ViewModel</summary>
    public class ResourceViewModel : ViewModelBase
    {

        #region Property

        /// <summary>選択している言語</summary>
        public Languages SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {

                _SelectedLanguage = value;
                CallPropertyChanged();

                // 言語切替
                switch (_SelectedLanguage)
                {
                    case Languages.English:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;

                    case Languages.Japanese:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
                        break;

                }

            }
        }

        /// <summary>メッセージボックス表示内容</summary>
        public MessageBoxInfo MessageInfo { get; set; }

        /// <summary>メッセージボックス表示コマンド</summary>
        public DelegateCommand MessageBoxCommand { get; private set; }

        #endregion

        /// <summary>選択している言語</summary>
        private Languages _SelectedLanguage;

        /// <summary>リソースファイルによる表示言語切替.ViewModel</summary>
        public ResourceViewModel()
        {

            // 初期値取得
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {

                case "en-US":
                    SelectedLanguage = Languages.English;
                    break;

                case "ja-JP":
                    SelectedLanguage = Languages.Japanese;
                    break;

            }

            MessageBoxCommand = new DelegateCommand(
                () => 
                {

                    // リソースファイルより表示内容を取得
                    MessageInfo = new MessageBoxInfo()
                    {
                        Message = LanguageSample.Message,
                        Title = LanguageSample.Title
                    };

                    CallPropertyChanged(nameof(MessageInfo));

                },
                () => true);

        }

    }

}
