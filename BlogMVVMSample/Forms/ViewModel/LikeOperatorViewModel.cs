using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>文字列の曖昧検索サンプル.ViewModel</summary>
    public class LikeOperatorViewModel : ViewModelBase
    {

        #region Model

        /// <summary>文字列の曖昧検索サンプル.Model</summary>
        private Model.LikeOperatorModel _Model = new Model.LikeOperatorModel();

        #endregion

        #region Property

        /// <summary>検索元文章</summary>
        public string Source { get; set; } = "Hello World!";

        /// <summary>検索する文字列</summary>
        public string Pattern { get; set; } = "*W*";

        /// <summary>検索結果</summary>
        public string Answer { get; set; }

        /// <summary>検索コマンド</summary>
        public DelegateCommand SearchCommand { get; private set; }

        #endregion

        /// <summary>文字列の曖昧検索サンプル.ViewModel</summary>
        public LikeOperatorViewModel()
        {

            SearchCommand = new DelegateCommand(
                () => 
                {

                    if (_Model.Contains(Source, Pattern))
                    {
                        Answer = "見つかりました";
                    }
                    else
                    {
                        Answer = "見つかりません";
                    }

                    CallPropertyChanged(nameof(Answer));

                }, 
                () => true);

        }

    }

}
