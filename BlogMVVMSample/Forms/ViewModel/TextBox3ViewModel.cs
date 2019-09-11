using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// TextBox3.ViewModel
    /// </summary>
    public class TextBox3ViewModel : ViewModelBase
    {

        #region Model

        private Model.TextBox3Model _Model;

        #endregion

        #region Property

        /// <summary>
        /// 表示No
        /// </summary>
        public int[] Numbers
        {
            get { return _Model.Numbers; }
            set { _Model.Numbers = value; }
        } 

        /// <summary>
        /// 表示No加算コマンド
        /// </summary>
        public DelegateCommand AddCommand { get; private set; }

        #endregion

        /// <summary>
        /// TextBox3.ViewModel
        /// </summary>
        public TextBox3ViewModel()
        {

            // Modelクラスの新規作成
            _Model = new Model.TextBox3Model();

            // 表示Noの値に10加算
            AddCommand = new DelegateCommand(
                () => 
                {

                    _Model.AddNumbers(10);
                    CallPropertyChanged(nameof(Numbers));

                },
                () => true);

        }

    }
}
