using System;
using System.Windows.Input;

namespace BlogMVVMSample.MVVM
{

    /// <summary>
    /// コマンド実装
    /// パラメータ有り
    /// </summary>
    /// <typeparam name="T">コマンドパラメータの型</typeparam>
    public class DelegateCommand<T> : ICommand
    {

        // 警告：CS0067を非表示にする
#pragma warning disable 0067

        /// <summary>CanExecute変更イベント</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>実行メソッド</summary>
        private readonly Action<T> _Execute;

        /// <summary>実行メソッド処理許可</summary>
        private readonly Func<bool> _CanExecute;

        /// <summary>コマンド実装</summary>
        /// <param name="execute">実行メソッド</param>
        /// <param name="canExecute">実行メソッド処理許可</param>
        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(execute));
            _CanExecute = canExecute ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(canExecute));
        }

        /// <summary>コマンドが実行可能か決定する</summary>
        public bool CanExecute()
        {
            return _CanExecute();
        }

        /// <summary>コマンドが実行可能か決定する</summary>
        /// <param name="parameter">パラメータ</param>
        public bool CanExecute(object parameter)
        {
            return _CanExecute();
        }

        /// <summary>コマンド実行</summary>
        /// <param name="parameter">パラメータ</param>
        public void Execute(object parameter)
        {
            _Execute((T)parameter);
        }

    }

    /// <summary>コマンド実装</summary>
    public class DelegateCommand : ICommand
    {

        // 警告：CS0067を非表示にする
#pragma warning disable 0067

        /// <summary>CanExecute変更イベント</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>実行メソッド</summary>
        private readonly Action _Execute;

        /// <summary>実行メソッド処理許可</summary>
        private readonly Func<bool> _CanExecute;

        /// <summary>コマンド実装</summary>
        /// <param name="execute">実行メソッド</param>
        /// <param name="canExecute">実行メソッド処理許可</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(execute));
            _CanExecute = canExecute ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(canExecute));
        }

        /// <summary>コマンドが実行可能か決定する</summary>
        public bool CanExecute()
        {
            return _CanExecute();
        }

        /// <summary>コマンドが実行可能か決定する</summary>
        /// <param name="parameter">パラメータ</param>
        public bool CanExecute(object parameter)
        {
            return _CanExecute();
        }

        /// <summary>コマンド実行</summary>
        public void Execute()
        {
            _Execute();
        }

        /// <summary>コマンド実行</summary>
        /// <param name="parameter">パラメータ</param>
        public void Execute(object parameter)
        {
            _Execute();
        }

    }
}
