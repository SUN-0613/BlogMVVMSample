using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>進捗バーViewModel</summary>
    public class ProgressBarViewModel : ViewModelBase
    {

        #region Model

        /// <summary>進捗バーModel</summary>
        public Model.ProgressBarModel _Model;

        #endregion

        #region Property

        /// <summary>入力許可</summary>
        public bool IsEnabled { get { return _Model.IsEnabled; } }

        /// <summary>処理時間</summary>
        public double Runtime { get; set; } = 10;

        /// <summary>処理開始コマンド</summary>
        public DelegateCommand RunCommand { get; private set; }

        /// <summary>進捗値</summary>
        public double Value { get { return _Model.Value; } }

        /// <summary>進捗最小値</summary>
        public double Minimum { get { return _Model.Minimum; } }

        /// <summary>進捗最大値</summary>
        public double Maximum { get { return _Model.Maximum; } }

        /// <summary>進捗メッセージ</summary>
       public string Message { get { return _Model.Message; } }

        #endregion

        /// <summary>進捗バーViewModel</summary>
        public ProgressBarViewModel()
        {

            _Model = new Model.ProgressBarModel();

            RunCommand = new DelegateCommand(
                () => 
                {
                    _Model.RunMethodASync(Runtime, CallPropertyChanged);
                }, 
                () => true);

        }

    }

}
