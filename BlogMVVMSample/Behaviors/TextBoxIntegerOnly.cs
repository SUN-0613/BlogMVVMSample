using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>
    /// TextBox用ビヘイビア
    /// 整数値のみを入力許可
    /// </summary>
    public class TextBoxIntegerOnly : BehaviorBase<TextBox>
    {

        /// <summary>
        /// イベント登録
        /// </summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // テキスト取得時の処理イベントの追加
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;

            // PreviewTextInputにてスペースをスルーしないようにする
            AssociatedObject.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.None));
            AssociatedObject.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.Space, ModifierKeys.Shift));

            // IMEモードを無効化
            InputMethod.SetIsInputMethodEnabled(AssociatedObject, false);

            // クリップボード処理
            AssociatedObject.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));

            // コンテキストメニュー無効化
            AssociatedObject.ContextMenu = null;

        }

        /// <summary>
        /// イベント解除
        /// </summary>
        protected override void OnDetaching()
        {

            base.OnDetaching();

            // テキスト取得時の処理イベントの解除
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;

            // 入力Bindingの初期化
            AssociatedObject.InputBindings.Clear();

            // クリップボード処理の初期化
            AssociatedObject.CommandBindings.Clear();

        }

        /// <summary>
        /// テキスト取得時の処理イベント
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">入力内容データ</param>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            // 整数値に変換できない場合は処理をキャンセル
            if (!int.TryParse(e.Text, out int resultValue))
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// クリップボード貼り付け時の処理イベント
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">実行イベントデータ</param>
        private void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

            // 整数値に変換できる場合は貼り付け処理を実行
            if (int.TryParse(Clipboard.GetText(), out int resultValue))
            {
                AssociatedObject.Paste();
            }

        }

    }

}
