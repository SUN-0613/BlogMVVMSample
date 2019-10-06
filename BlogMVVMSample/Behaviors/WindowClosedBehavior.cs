using System;
using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>Windowの閉じる処理でViewModelのDisposeを実行するビヘイビア</summary>
    public class WindowClosedBehavior : Behavior<Window>
    {

        /// <summary>イベント登録</summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // Windowが閉じられた時の処理イベントにOnClosed()を追加
            AssociatedObject.Closed += OnClosed;

        }

        /// <summary>イベント解除</summary>
        protected override void OnDetaching()
        {

            base.OnDetaching();

            // Windowが閉じられた時の処理イベントからOnClosed()を解除
            AssociatedObject.Closed -= OnClosed;

        }

        /// <summary>Windowが閉じられた時の処理イベント</summary>
        /// <param name="sender">Window</param>
        /// <param name="e">イベントデータ</param>
        private void OnClosed(object sender, EventArgs e)
        {

            if (AssociatedObject.DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }

        }

    }

}
