using System;
using System.Collections.Generic;

namespace BlogMVVMSample.Class
{

    /// <summary>List()にリソース開放処理</summary>
    /// <typeparam name="T">型指定</typeparam>
    public class DisposableList<T> : List<T>, IDisposable
    {

        /// <summary>開放処理</summary>
        public void Dispose()
        {

            // List()内要素にてリソース解放が必要なら実施
            ForEach(value =>
            {

                if (value is IDisposable disposable)
                {
                    disposable.Dispose();
                }

            });

            // List()から全ての要素を削除
            Clear();

        }

    }

}
