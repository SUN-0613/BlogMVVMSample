using BlogMVVMSample.Data;
using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>
    /// MessageBoxを表示するためのビヘイビア
    /// </summary>
    public class MessageBoxBehavior : TriggerAction<FrameworkElement>
    {

        /// <summary>
        /// MessageBoxを表示
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        protected override void Invoke(object parameter)
        {

            if (parameter is DependencyPropertyChangedEventArgs e
                && e.NewValue is MessageBoxInfo info)
            {
                info.Result = MessageBox.Show(info.Message, info.Title, info.Button, info.Image, info.DefaultResult, info.Options);
            }

        }

    }

}
