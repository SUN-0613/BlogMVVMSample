using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>文字列の曖昧検索サンプル.Model</summary>
    public class LikeOperatorModel
    {

        /// <summary>検索元文章と検索する文字列が一致するかチェック</summary>
        /// <param name="source">検索対象の文章</param>
        /// <param name="pattern">検索する文字列</param>
        public bool Contains(string source, string pattern)
        {

            // 大文字⇔小文字、全角⇔半角、ひらがな⇔カタカナを区別する場合、CompareMethod.Binaryを使用
            return LikeOperator.LikeString(source, pattern, CompareMethod.Text);

        }

    }

}
