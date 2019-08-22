using System.ComponentModel;

namespace BlogMVVMSample.MVVM
{

    /// <summary>
    /// ViewModel.ベースクラス
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// プロパティ変更イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged()呼び出し
        /// </summary>
        /// <param name="propertyName">イベントを発生させたいプロパティ名</param>
        protected void CallPropertyChanged(string propertyName)
        {

            // イベント発生
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }

}
