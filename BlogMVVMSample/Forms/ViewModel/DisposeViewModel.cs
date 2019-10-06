using BlogMVVMSample.MVVM;
using System;
using System.Diagnostics;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>ViewModelのDisposeを行うビヘイビアの使用サンプル.ViewModel</summary>
    public class DisposeViewModel : ViewModelBase, IDisposable
    {

        /// <summary>解放処理</summary>
        public void Dispose()
        {
            Debug.WriteLine("Dispose()");
        }

    }

}
