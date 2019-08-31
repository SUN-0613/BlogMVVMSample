using System;
using System.Windows;
using System.Windows.Controls;

namespace BlogMVVMSample.Custom
{

    /// <summary>
    /// TreeViewカスタマイズ
    /// Binding可能なSelectedItemを追加
    /// </summary>
    public class CustomTreeView : TreeView, IDisposable
    {

        #region DependencyProperty

        /// <summary>
        /// SelectedItem依存プロパティ
        /// </summary>
        public static readonly DependencyProperty CustomSelectedItemProperty
            = DependencyProperty.Register(
                nameof(CustomSelectedItem)
                , typeof(object)
                , typeof(CustomTreeView)
                , new UIPropertyMetadata(null)
                );

        #endregion

        #region Property

        /// <summary>
        /// SelectedItemプロパティ
        /// </summary>
        public object CustomSelectedItem
        {
            get { return GetValue(CustomSelectedItemProperty); }
            set { SetValue(CustomSelectedItemProperty, value); }
        }

        #endregion

        #region Event

        /// <summary>
        /// SelectedItem変更イベント
        /// </summary>
        protected void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(CustomSelectedItemProperty, SelectedItem);
            }
        }

        #endregion

        /// <summary>
        /// TreeViewカスタマイズ
        /// </summary>
        public CustomTreeView()
        {
            SelectedItemChanged += OnSelectedItemChanged;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            SelectedItemChanged -= OnSelectedItemChanged;
        }

    }

}
