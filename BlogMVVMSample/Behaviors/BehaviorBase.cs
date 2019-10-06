using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>初期化／終了処理を行うビヘイビアベースクラス</summary>
    /// <typeparam name="T">対象コントロール</typeparam>
    public abstract class BehaviorBase<T> : Behavior<T> where T : FrameworkElement
    {

        /// <summary>OnDetaching()実行終了FLG</summary>
        private bool _IsDetaching = false;

        /// <summary>イベント登録</summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // UnloadedイベントにOnUnLoaded()を登録
            AssociatedObject.Unloaded += OnUnloaded;

        }

        /// <summary>イベント解除</summary>
        protected override void OnDetaching()
        {

            if (!_IsDetaching)
            {

                base.OnDetaching();

                // UnloadedイベントからOnUnLoaded()を解除
                AssociatedObject.Unloaded -= OnUnloaded;

                // FLG更新
                _IsDetaching = true;

            }

        }

        /// <summary>UnLoadedイベント</summary>
        /// <param name="sender">対象コントロール</param>
        /// <param name="e">イベントデータ</param>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {

            // OnDetaching()が未実行であるならイベントを強制実行する
            if (!_IsDetaching)
            {
                OnDetaching();
            }

        }

    }

}
