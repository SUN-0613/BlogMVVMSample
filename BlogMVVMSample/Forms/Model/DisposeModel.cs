using System;
using System.Diagnostics;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>ViewModelのDisposeを行うビヘイビアの使用サンプル.Model</summary>
    public class DisposeModel : IDisposable
    {

        /// <summary>解放処理</summary>
        public void Dispose()
        {
            Debug.WriteLine("Dispose()");
        }

    }

}
