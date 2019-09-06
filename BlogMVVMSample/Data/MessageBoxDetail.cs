using System.Windows;

namespace BlogMVVMSample.Data
{

    /// <summary>
    /// メッセージボックス表示内容
    /// </summary>
    public class MessageBoxDetail
    {

        /// <summary>
        /// 表示するテキスト
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 表示するタイトルバー
        /// </summary>
        public string Caption { get; set; } = "";

        /// <summary>
        /// 表示するボタンを指定する値
        /// </summary>
        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;

        /// <summary>
        /// 表示するアイコンを指定する値
        /// </summary>
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        /// <summary>
        /// 規定の結果を指定する値
        /// </summary>
        public MessageBoxResult DefaultResult { get; set; } = MessageBoxResult.None;

        /// <summary>
        /// オプションを指定する値オブジェクト
        /// </summary>
        public MessageBoxOptions Options { get; set; } = MessageBoxOptions.None;

        /// <summary>
        /// 結果
        /// </summary>
        public MessageBoxResult Result { get; set; } = MessageBoxResult.None;

    }

}
