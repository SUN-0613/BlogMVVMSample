using System;
using System.Windows;

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

            var form = new Forms.View.DisposeView();

            form.ShowDialog();

            var form2 = new Forms.View.DragAndDropView();

            form2.ShowDialog();

            Shutdown();

        }

    }
}