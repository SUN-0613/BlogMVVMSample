using BlogMVVMSample.MVVM;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class CheckBoxViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// TextBoxに入力可能か
        /// </summary>
        public bool IsEditing
        {
            get { return _IsEditing; }
            set
            {
                _IsEditing = value;
                CallPropertyChanged();
                CallPropertyChanged(nameof(IsReadOnly));
            }
        }

        /// <summary>
        /// 読取専用
        /// </summary>
        public bool IsReadOnly { get { return !_IsEditing; } }

        /// <summary>
        /// 文章
        /// </summary>
        public string Text { get; set; }

        #endregion

        /// <summary>
        /// TextBoxに入力可能か
        /// </summary>
        private bool _IsEditing = false;

    }

}
