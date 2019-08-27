using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class ComboBox2ViewModel : ViewModelBase
    {

        #region Model

        /// <summary>
        /// Model
        /// </summary>
        private Model.ComboBox2Model _Model = new Model.ComboBox2Model();

        #endregion

        #region Property

        /// <summary>
        /// 仕事の状態
        /// </summary>
        public JobStatus SelectedStatus
        {
            get { return _Model.SelectedStatus; }
            set
            {

                _Model.SelectedStatus = value;

                // 選択した内容に沿った文章を表示
                CallPropertyChanged(nameof(Message));

            }
        }

        /// <summary>
        /// 文章
        /// </summary>
        public string Message { get { return _Model.GetMessage(); } }

        #endregion

    }

}
