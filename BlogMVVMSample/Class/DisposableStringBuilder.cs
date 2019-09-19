using System;
using System.Text;

namespace BlogMVVMSample.Class
{

    /// <summary>StringBuilderでリソース解放処理</summary>
    public class DisposableStringBuilder : IDisposable
    {

        /// <summary>StringBuilder</summary>
        private StringBuilder _StringBuilder;

        /// <summary>StringBuilderでリソース解放処理</summary>
        public DisposableStringBuilder()
        {
            _StringBuilder = new StringBuilder();
        }

        /// <summary>StringBuilderでリソース解放処理</summary>
        /// <param name="capacity">推奨開始サイズ</param>
        public DisposableStringBuilder(int capacity)
        {
            _StringBuilder = new StringBuilder(capacity);
        }

        /// <summary>開放処理</summary>
        public void Dispose()
        {
            _StringBuilder.Clear();
            _StringBuilder = null;
        }

        /// <summary>文字列の長さを取得、設定</summary>
        public int Length
        {
            get { return _StringBuilder.Length; }
            set { _StringBuilder.Length = value; }
        }

        /// <summary>文字列追加</summary>
        /// <param name="value">追加文字列</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder Append(string value)
        {
            return _StringBuilder.Append(value);
        }

        /// <summary>末尾に改行コードを追加</summary>
        /// <returns>StringBuilder</returns>
        public StringBuilder AppendLine()
        {
            return _StringBuilder.AppendLine();
        }

        /// <summary>末尾に改行コードを追加</summary>
        /// <param name="value">追加文字列</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder AppendLine(string value)
        {
            return _StringBuilder.AppendLine(value);
        }

        /// <summary>引数のオブジェクトが自身と同一のものかチェック</summary>
        /// <param name="stringBuilder">引数のオブジェクト</param>
        /// <returns>
        /// true:同一である
        /// false:同一でない
        /// </returns>
        public bool Equals(StringBuilder stringBuilder)
        {
            return _StringBuilder.Equals(stringBuilder);
        }

        /// <summary>指定した文字位置に文字列を挿入</summary>
        /// <param name="index">指定した文字位置</param>
        /// <param name="value">挿入文字列</param>
        /// <returns>StringBuilder</returns>
        public StringBuilder Insert(int index, string value)
        {
            return _StringBuilder.Insert(index, value);
        }

        /// <summary>StringBuilderの持つ文字列をstring型に変換</summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return _StringBuilder.ToString();
        }

        /// <summary>StringBuilderの持つ文字列をstring型に変換</summary>
        /// <param name="startIndex">開始位置</param>
        /// <param name="length">文字数</param>
        /// <returns>文字列</returns>
        public string ToString(int startIndex, int length)
        {
            return _StringBuilder.ToString(startIndex, length);
        }

    }

}
