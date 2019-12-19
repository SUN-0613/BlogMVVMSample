using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>ResourceDictionaryによる表示言語切替.ViewModel</summary>
    public class ResourceDictionaryViewModel : ViewModelBase
    {

        /// <summary>ResourceDictionaryのファイル名</summary>
        private const string _FileName = "LanguageDictionary";

        #region Property

        /// <summary>表示言語情報</summary>
        public LanguageInfo LanguageInfo { get; private set; } = new LanguageInfo(_FileName);

        /// <summary>選択している言語</summary>
        private Languages _SelectedLanguage;

        /// <summary>選択している言語</summary>
        public Languages SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {

                _SelectedLanguage = value;

                // 言語切替
                LanguageInfo = new LanguageInfo(_FileName, value);
                CallPropertyChanged(nameof(LanguageInfo));

                // テキスト更新
                UpdateText = LanguageInfo.LanguageDictionary["Message"].ToString();
                CallPropertyChanged(nameof(UpdateText));

            }
        }

        /// <summary>ResourceDictionary更新用テキスト</summary>
        public string UpdateText { get; set; }

        /// <summary>ResourceDictionary更新コマンド</summary>
        public DelegateCommand UpdateCommand { get; private set; }

        #endregion

        /// <summary>ResourceDictionaryによる表示言語切替.ViewModel</summary>
        public ResourceDictionaryViewModel()
        {

            SelectedLanguage = LanguageInfo.SelectedLanguage;

            UpdateCommand = new DelegateCommand(
                () => 
                {

                    // ResourceDictionaryの値を更新してファイルに保存
                    LanguageInfo.LanguageDictionary["Message"] = UpdateText;
                    LanguageInfo.UpdateResourceDictionary();

                },
                () => true);

        }

    }

}
