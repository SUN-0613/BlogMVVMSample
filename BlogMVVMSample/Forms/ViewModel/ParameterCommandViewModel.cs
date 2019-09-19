using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>パラメータ有DelegateCommandサンプル.ViewModel</summary>
    public class ParameterCommandViewModel : ViewModelBase
    {

        #region Property

        /// <summary>ボタンコマンド</summary>
        public DelegateCommand<string> ButtonCommand { get; private set; }

        /// <summary>テキスト表示</summary>
        public string Text { get; private set; } = "";

        #endregion

        /// <summary>パラメータ有DelegateCommandサンプル.ViewModel</summary>
        public ParameterCommandViewModel()
        {

            // パラメータ付ボタンコマンドの実装
            ButtonCommand = new DelegateCommand<string>(
                (parameter) => 
                {
                    Text = parameter;
                    CallPropertyChanged(nameof(Text));
                }, 
                () => true);

        }

    }
}
