using BlogMVVMSample.MVVM;
using System;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// カレンダーViewModel
    /// </summary>
    public class CalendarViewModel : ViewModelBase
    {

        #region Property

        /// <summary>
        /// カレンダーで選択している日付
        /// </summary>
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                _SelectedDate = value;
                CallPropertyChanged();
            }
        }

        /// <summary>
        /// カレンダー表示範囲の最初の日付
        /// </summary>
        public DateTime DisplayDateStart { get; set; }

        /// <summary>
        /// カレンダー表示範囲の最後の日付
        /// </summary>
        public DateTime DisplayDateEnd { get; set; }

        #endregion

        /// <summary>
        /// カレンダーで選択している日付
        /// </summary>
        private DateTime _SelectedDate = DateTime.Now;

        /// <summary>
        /// カレンダーViewModel
        /// </summary>
        public CalendarViewModel()
        {

            // カレンダーの表示範囲：今年の元日～大晦日
            DisplayDateStart = new DateTime(DateTime.Now.Year, 1, 1);
            DisplayDateEnd = new DateTime(DateTime.Now.Year, 12, 31);

        }

    }

}
