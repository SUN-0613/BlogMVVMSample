using BlogMVVMSample.MVVM;
using System.Collections;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>ドラッグ＆ドロップ.ViewModel</summary>
    public class DragAndDropViewModel : ViewModelBase
    {

        #region Property

        /// <summary>パス一覧</summary>
        public IList Paths
        {
            get { return _Paths; }
            set
            {
                _Paths = value;
                CallPropertyChanged();
            }
        }

        #endregion

        /// <summary>パス一覧</summary>
        private IList _Paths;

    }
}
