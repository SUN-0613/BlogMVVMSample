using System.ComponentModel;
using System.Diagnostics;

namespace BlogMVVMSample.MVVM
{

    /// <summary>
    /// ViewModel.ベースクラス
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// プロパティ変更イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged()呼び出し
        /// </summary>
        protected virtual void CallPropertyChanged()
        {

            // 呼び出し元メソッド名をプロパティ名として取得
            var caller = new StackFrame(1);                         // 呼び出し元メソッド情報
            var methodNames = caller.GetMethod().Name.Split('_');   // 呼び出し元メソッド名
            var propertyName = methodNames[methodNames.Length - 1];

            CallPropertyChanged(propertyName);

        }

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
