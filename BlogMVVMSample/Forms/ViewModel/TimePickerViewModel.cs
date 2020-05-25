using BlogMVVMSample.MVVM;
using System;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// UserControlのTimePickerサンプルViewModel
    /// </summary>
    public class TimePickerViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// 選択時間
        /// </summary>
        private TimeSpan _SelectedTime = DateTime.Now.TimeOfDay;

        /// <summary>
        /// 選択時間
        /// </summary>
        public TimeSpan SelectedTime
        {
            get { return _SelectedTime; }
            set
            {
                _SelectedTime = value;
                CallPropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// UserControlのTimePickerサンプルViewModel
        /// </summary>
        public TimePickerViewModel()
        { }

    }

}
