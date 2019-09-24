using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>進捗バーModel</summary>
    public class ProgressBarModel
    {

        #region ViewModel.Property

        /// <summary>入力許可</summary>
        public bool IsEnabled = true;

        /// <summary>進捗値</summary>
        public double Value = 0d;

        /// <summary>進捗最小値</summary>
        public double Minimum = 0d;

        /// <summary>進捗最大値</summary>
        public double Maximum = 100d;

        /// <summary>進捗メッセージ</summary>
        public string Message = "";

        #endregion

        /// <summary>何かしらの処理</summary>
        /// <param name="runtime">処理時間</param>
        /// <param name="callPropertyChanged">ViewModelのプロパティ変更イベント呼び出しメソッド</param>
        public async void RunMethodASync(double runtime, Action<string> callPropertyChanged)
        {

            // 初期値設定
            IsEnabled = false;
            Value = 0d;
            Minimum = 0d;
            Maximum = runtime;

            Message = "何か重たい処理を続行中...";

            // ViewModelでプロパティ変更イベントを実行
            callPropertyChanged(nameof(IsEnabled));
            callPropertyChanged(nameof(Value));
            callPropertyChanged(nameof(Minimum));
            callPropertyChanged(nameof(Maximum));
            callPropertyChanged(nameof(Message));

            // 何か時間がかかる処理
            await Task.Run(() => 
            {

                while (Value < Maximum)
                {

                    Thread.Sleep(100);
                    Value += 0.1;
                    callPropertyChanged(nameof(Value));

                }

            });

            // 終了メッセージ表示
            Value = Maximum;
            Message = "終了しました";
            IsEnabled = true; 

            // ViewModelでプロパティ変更イベントを実行
            callPropertyChanged(nameof(Value));
            callPropertyChanged(nameof(Message));
            callPropertyChanged(nameof(IsEnabled));

        }

    }

}
