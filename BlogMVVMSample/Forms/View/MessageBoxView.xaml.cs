using BlogMVVMSample.MVVM;
using System;
using System.ComponentModel;
using System.Windows;

namespace BlogMVVMSample.Forms.View
{

    /// <summary>
    /// メッセージボックス出力View の相互作用ロジック
    /// </summary>
    public partial class MessageBoxView : Window, IDisposable
    {

        /// <summary>
        /// メッセージボックス出力View の相互作用ロジック
        /// </summary>
        public MessageBoxView()
        {

            InitializeComponent();

            // ViewModelのプロパティ変更イベントにイベントハンドラ追加
            if (DataContext is ViewModelBase viewModel)
            {
                viewModel.PropertyChanged += OnPropertyChanged;
            }

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            // ViewModelのプロパティ変更イベントからイベントハンドラ削除
            if (DataContext is ViewModelBase viewModel)
            {
                viewModel.PropertyChanged -= OnPropertyChanged;
            }

        }

        /// <summary>
        /// ViewModelプロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="sender">ViewModel</param>
        /// <param name="e">変更したプロパティ</param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            // 変更されたプロパティの名称を確認
            switch (e.PropertyName)
            {

                case "CallMessageBox":
                    MessageBox.Show("Hello World!", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                default:
                    break;

            }

        }

    }

}
