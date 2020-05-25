using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BlogMVVMSample.UserControls
{
    /// <summary>
    /// TimePicker.xaml の相互作用ロジック
    /// </summary>
    public partial class TimePicker : UserControl, INotifyPropertyChanged
    {

        #region INotifyPropertyChanged

        /// <summary>
        /// プロパティ変更イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged()の実行
        /// </summary>
        /// <param name="propertyName"></param>
        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region DependecyProperty

        /// <summary>
        /// 選択時間の依存プロパティ
        /// </summary>
        public static readonly DependencyProperty SelectedTimeProperty
            = DependencyProperty.Register(
                nameof(SelectedTime),
                typeof(TimeSpan),
                typeof(TimePicker),
                new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Property

        /// <summary>
        /// 選択時間
        /// </summary>
        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set
            {

                SetValue(SelectedTimeProperty, value);

                CallPropertyChanged(nameof(SelectedHour));
                CallPropertyChanged(nameof(SelectedMinute));
                CallPropertyChanged(nameof(SelectedSecond));

            }
        }

        /// <summary>
        /// 時間一覧
        /// </summary>
        public ObservableCollection<int> Hours { get; set; } = new ObservableCollection<int>();

        /// <summary>
        /// 分一覧
        /// </summary>
        public ObservableCollection<int> Minutes { get; set; } = new ObservableCollection<int>();

        /// <summary>
        /// 秒一覧
        /// </summary>
        public ObservableCollection<int> Seconds { get; set; } = new ObservableCollection<int>();

        /// <summary>
        /// 選択「時」
        /// </summary>
        public int SelectedHour
        {
            get { return SelectedTime.Hours; }
            set
            {

                SelectedTime = new TimeSpan(value, SelectedTime.Minutes, SelectedTime.Seconds);

                CallPropertyChanged(nameof(SelectedTime));

            }
        }

        /// <summary>
        /// 選択「分」
        /// </summary>
        public int SelectedMinute
        {
            get { return SelectedTime.Minutes; }
            set
            {

                SelectedTime = new TimeSpan(SelectedTime.Hours, value, SelectedTime.Seconds);

                CallPropertyChanged(nameof(SelectedTime));

            }
        }

        /// <summary>
        /// 選択「秒」
        /// </summary>
        public int SelectedSecond
        {
            get { return SelectedTime.Seconds; }
            set
            {

                SelectedTime = new TimeSpan(SelectedTime.Hours, SelectedTime.Minutes, value);

                CallPropertyChanged(nameof(SelectedTime));

            }
        }

        #endregion

        public TimePicker()
        {

            InitializeComponent();

            for (var i = 0; i < 24; i++)
            {
                Hours.Add(i);
            }

            for (var i = 0; i < 60; i++)
            {
                Minutes.Add(i);
                Seconds.Add(i);
            }

        }

    }

}
