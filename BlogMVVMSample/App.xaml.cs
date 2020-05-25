using System;
using System.Windows;

namespace BlogMVVMSample
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        /// <summary>プログラム起動</summary>
        /// <param name="e">プログラム起動イベントデータ</param>
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            new Forms.View.TimePickerView().ShowDialog();

            Shutdown();

        }

    }
}