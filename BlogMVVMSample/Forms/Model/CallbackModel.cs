using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>Callbackサンプル.Model</summary>
    public class CallbackModel
    {

        #region delegate

        /// <summary>カウントダウン更新用コールバック</summary>
        /// <param name="value"></param>
        public delegate void UpdateCountdownCallback(int sec);

        #endregion

        /// <summary>乱数を取得して一覧を作成する</summary>
        /// <param name="countdownCallback">カウントダウン更新用コールバック</param>
        /// <param name="collectionCallback">一覧更新用コールバック</param>
        public ObservableCollection<int> MakeCollection(UpdateCountdownCallback countdownCallback)
        {

            const int countdownMax = 5;

            var values = new ObservableCollection<int>();
            var random = new Random();
            var stopwatch = new Stopwatch();
            int countdown = -1;

            stopwatch.Start();

            // 5秒間、乱数を生成して一覧に追加
            while (countdown < countdownMax)
            {

                values.Add(random.Next());

                // 秒毎にカウントダウンコールバックを呼び出す
                if (!countdown.Equals(stopwatch.Elapsed.Seconds))
                {
                    countdown = stopwatch.Elapsed.Seconds;
                    countdownCallback(countdownMax - countdown);
                }

            }

            countdownCallback(0);
            stopwatch.Stop();

            return values;

        }

    }

}
