using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace BlogMVVMSample.Custom
{

    /// <summary>
    /// ListViewカスタマイズ
    /// </summary>
    /// <remarks>
    /// SelectedItemsをBinding可
    /// </remarks>
    public class CustomListView : ListView
    {

        #region DependencyProperty

        /// <summary>
        /// SelectedItems依存プロパティ
        /// </summary>
        public static readonly DependencyProperty CustomSelectedItemsProperty
            = DependencyProperty.Register(
                nameof(CustomSelectedItems)
                , typeof(IList)
                , typeof(CustomListView)
                , new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
                );

        #endregion

        #region Property

        /// <summary>
        /// SelectedItemsプロパティ
        /// </summary>
        public IList CustomSelectedItems
        {
            get { return (IList)GetValue(CustomSelectedItemsProperty); }
            set { SetValue(CustomSelectedItemsProperty, value); }
        }

        #endregion

        #region Event

        /// <summary>
        /// SelectedItems変更イベント
        /// </summary>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {

            base.OnSelectionChanged(e);

            CustomSelectedItems = SelectedItems;

        }

        #endregion

    }

}
