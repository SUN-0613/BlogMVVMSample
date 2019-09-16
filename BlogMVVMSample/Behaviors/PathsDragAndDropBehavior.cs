using System.Collections;
using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>パスのドラッグ＆ドロップ処理を行うビヘイビア</summary>
    public class PathsDragAndDropBehavior : Behavior<FrameworkElement>
    {

        #region DependencyProperty

        /// <summary>ドロップされたパス一覧依存プロパティ</summary>
        public static readonly DependencyProperty DropFilesProperty
            = DependencyProperty.Register(
                nameof(DropFiles)
                , typeof(IList)
                , typeof(PathsDragAndDropBehavior)
                , new PropertyMetadata(null)
                );

        #endregion

        #region Property

        /// <summary>ドロップされたパス一覧プロパティ</summary>
        public IList DropFiles
        {
            get { return (IList)GetValue(DropFilesProperty); }
            set { SetValue(DropFilesProperty, value); }
        }

        #endregion

        /// <summary>イベント登録</summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // ドラッグ＆ドロップイベントにメソッド処理追加
            AssociatedObject.PreviewDragOver += OnPreviewDragOver;
            AssociatedObject.Drop += OnDrop;

        }

        /// <summary>イベント解除</summary>
        protected override void OnDetaching()
        {

            base.OnDetaching();

            // ドラッグ＆ドロップイベントからメソッド処理解除
            AssociatedObject.PreviewDragOver -= OnPreviewDragOver;
            AssociatedObject.Drop -= OnDrop;

        }

        /// <summary>パスドラッグイベント</summary>
        /// <param name="sender">FrameworkElement</param>
        /// <param name="e">ドラッグ内容データ</param>
        private void OnPreviewDragOver(object sender, DragEventArgs e)
        {

            // ドラッグデータがファイルフォーマットかチェック
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {

                // ファイルならコピー形式でドロップ
                e.Effects = DragDropEffects.Copy;

            }
            else
            {

                // ドロップ処理のキャンセル
                e.Effects = DragDropEffects.None;

            }

            // ドラッグ操作のキャンセル
            e.Handled = true;

        }

        /// <summary>パスドロップイベント</summary>
        /// <param name="sender">FrameworkElement</param>
        /// <param name="e">ドロップ内容データ</param>
        private void OnDrop(object sender, DragEventArgs e)
        {

            // ドロップ情報をIListに変換
            DropFiles = e.Data.GetData(DataFormats.FileDrop) as IList;

        }

    }

}
