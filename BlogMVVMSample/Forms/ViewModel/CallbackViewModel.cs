using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>Callbackサンプル.ViewModel</summary>
    public class CallbackViewModel : ViewModelBase
    {

        #region Model

        /// <summary>Callbackサンプル.Model</summary>
        private Model.CallbackModel _Model;

        #endregion

        #region Property

        /// <summary>カウントダウン</summary>
        public int CountDown { get; private set; }

        /// <summary>数値一覧</summary>
        public ObservableCollection<int> Values { get; private set; }

        /// <summary>一覧作成コマンド</summary>
        public DelegateCommand MakeListCommand { get; }

        #endregion

        /// <summary>Callbackサンプル.ViewModel</summary>
        public CallbackViewModel()
        {

            _Model = new Model.CallbackModel();

            MakeListCommand = new DelegateCommand(
                () => 
                {

                    // メモリ解放
                    if (Values != null)
                    {
                        Values.Clear();
                        Values = null;
                    }

                    Task.Run(() => 
                    {

                        // コールバックをローカル関数で宣言
                        void countdownCallback(int value)
                        {
                            CountDown = value;
                            CallPropertyChanged(nameof(CountDown));
                        }

                        Values = _Model.MakeCollection(countdownCallback);
                        CallPropertyChanged(nameof(Values));

                    });

                }, 
                () => true);

        }

    }

}
