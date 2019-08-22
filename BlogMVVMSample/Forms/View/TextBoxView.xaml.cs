using System.Windows;

namespace BlogMVVMSample.Forms.View
{
    /// <summary>
    /// View
    /// </summary>
    public partial class TextBoxView : Window
    {

        /// <summary>
        /// View
        /// </summary>
        public TextBoxView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TextBoxにHello World!を表示
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DataContext is ViewModel.TextBoxViewModel viewModel)
            {
                viewModel.InputTextBox();
            }

        }

    }

}
