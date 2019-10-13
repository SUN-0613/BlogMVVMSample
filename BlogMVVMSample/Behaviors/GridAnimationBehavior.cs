using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>色々なコントロールを描画するGridを自動的に隠すビヘイビア</summary>
    public class GridAnimationBehavior : BehaviorBase<Grid>
    {

        /// <summary>イベント登録</summary>
        protected override void OnAttached()
        {

            base.OnAttached();

            // 読み込み完了後のイベント登録
            AssociatedObject.Loaded += OnLoaded;

            // マウス動作のイベント登録
            AssociatedObject.MouseLeave += OnMouseLeave;
            AssociatedObject.MouseEnter += OnMouseEnter;

        }

        /// <summary>イベント解除</summary>
        protected override void OnDetaching()
        {

            base.OnDetaching();

            // 読み込み完了後のイベント解除
            AssociatedObject.Loaded -= OnLoaded;

            // マウス動作のイベント解除
            AssociatedObject.MouseLeave -= OnMouseLeave;
            AssociatedObject.MouseEnter -= OnMouseEnter;

        }

        /// <summary>Gridの読み込み完了後のイベント</summary>
        /// <param name="sender">Grid</param>
        /// <param name="e">イベントデータ</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            HiddenGrid();
        }

        /// <summary>マウスカーソルがGrid上から離れた時のイベント</summary>
        /// <param name="sender">Grid</param>
        /// <param name="e">イベントデータ</param>
        private void OnMouseLeave(object sender, EventArgs e)
        {
            HiddenGrid();
        }

        /// <summary>マウスカーソルがGrid上に移動した時のイベント</summary>
        /// <param name="sender">Grid</param>
        /// <param name="e">イベントデータ</param>
        private void OnMouseEnter(object sender, EventArgs e)
        {
            VisibleGrid();
        }

        /// <summary>Gridを隠す</summary>
        private void HiddenGrid()
        {

            // アニメーションの初期設定
            var animation = new ThicknessAnimation();

            Storyboard.SetTarget(animation, AssociatedObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.MarginProperty));

            // Gridの移動量の計算
            var movement = AssociatedObject.ActualHeight - 5d;

            // マウスが離れた時に0.5秒ほどで隠れるようにMarginを調整する
            animation.From = AssociatedObject.Margin;
            animation.To = new Thickness(0, movement, 0, (-1d) * movement);
            animation.Duration = TimeSpan.FromMilliseconds(500);

            // アニメーションをストーリーボードに登録し、処理開始
            var story = new Storyboard();
            story.Children.Add(animation);
            story.Begin();

        }

        /// <summary>Gridを表示する</summary>
        private void VisibleGrid()
        {

            // アニメーションの初期設定
            var animation = new ThicknessAnimation();

            Storyboard.SetTarget(animation, AssociatedObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.MarginProperty));

            // マウスが移動してきた時に0.5秒ほどで表示するようにMarginを調整する
            animation.From = AssociatedObject.Margin;
            animation.To = new Thickness(0, 0, 0, 0);
            animation.Duration = TimeSpan.FromMilliseconds(500);
            animation.Freeze();

            // アニメーションをストーリーボードに登録し、処理開始
            var story = new Storyboard();
            story.Children.Add(animation);
            story.Begin();

        }

    }

}
