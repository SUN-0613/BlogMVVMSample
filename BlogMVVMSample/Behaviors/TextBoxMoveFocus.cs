using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>
    /// TextBox用ビヘイビア
    /// Enter、カーソルキーで次フォーカス移動
    /// </summary>
    public class TextBoxMoveFocus : BehaviorBase<TextBox>
    {

        /// <summary>
        /// イベント登録
        /// </summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // TextBoxのキーダウンイベントにOnKeyDownを登録
            AssociatedObject.PreviewKeyDown += OnPreviewKeyDown;

        }

        /// <summary>
        /// イベント解除
        /// </summary>
        protected override void OnDetaching()
        {

            base.OnDetaching();

            // TextBoxのキーダウンイベントからOnKeyDownを解除
            AssociatedObject.PreviewKeyDown -= OnPreviewKeyDown;

        }

        /// <summary>
        /// キー押下イベント
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e">キーイベントデータ</param>
        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (sender is TextBox textBox)
            {

                // フォーカス移動要求
                TraversalRequest request = null;

                switch (e.Key)
                {

                    case Key.Enter:

                        // Shiftキーが押されているか
                        var isShift = Keyboard.Modifiers.Equals(ModifierKeys.Shift);

                        // 通常は次フォーカスへ移動
                        // Shiftキー押下時は前フォーカスへ移動
                        request = new TraversalRequest(isShift ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);

                        break;

                    case Key.Left:

                        // キャレットの位置が先頭にある場合にフォーカス移動を行う
                        if (textBox.SelectionStart.Equals(0))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Left);
                        }

                        break;

                    case Key.Right:

                        // キャレットの位置が末尾にある場合にフォーカス移動を行う
                        if (textBox.SelectionStart.Equals(textBox.Text.Length))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Right);
                        }

                        break;

                    case Key.Up:

                        // 単行入力の場合は無条件でフォーカス移動を行う
                        // 複数行入力の場合、キャレットの位置が先頭にある場合にフォーカス移動を行う
                        if (!textBox.AcceptsReturn || textBox.SelectionStart.Equals(0))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Up);
                        }

                        break;

                    case Key.Down:

                        // 単行入力の場合は無条件でフォーカス移動を行う
                        // 複数行入力の場合、キャレットの位置が末尾にある場合にフォーカス移動を行う
                        if (!textBox.AcceptsReturn || textBox.SelectionStart.Equals(textBox.Text.Length))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Down);
                        }

                        break;

                    default:
                        break;

                }

                // フォーカス移動を実行
                if (request != null)
                {

                    textBox.MoveFocus(request);

                }

            }

        }

    }
}
