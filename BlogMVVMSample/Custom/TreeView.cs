using System;
using System.Windows;
using System.Windows.Controls;

namespace BlogMVVMSample.Custom
{

    /// <summary>
    /// TreeViewカスタマイズ
    /// Binding可能なSelectedItemを追加
    /// </summary>
    public class CustomTreeView : TreeView
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
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {

            base.OnSelectedItemChanged(e);

            SetValue(CustomSelectedItemProperty, SelectedItem);

        }

        #endregion

    }

}
