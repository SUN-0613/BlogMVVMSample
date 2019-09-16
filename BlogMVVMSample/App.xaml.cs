using System.Windows;
using System.Diagnostics;

namespace BlogMVVMSample
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            new Forms.View.DragAndDropView().ShowDialog();

        }

    }
}
