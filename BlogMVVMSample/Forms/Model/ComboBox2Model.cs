using BlogMVVMSample.Data;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>
    /// Model
    /// </summary>
    public class ComboBox2Model
    {

        #region Property

        /// <summary>
        /// 仕事の状態
        /// </summary>
        public JobStatus SelectedStatus;

        #endregion

        /// <summary>
        /// 文章取得
        /// </summary>
        public string GetMessage()
        {

            switch (SelectedStatus)
            {

                case JobStatus.NotOrdered:
                    return "この仕事はまだ受注していません。";

                case JobStatus.Ordered:
                    return "この仕事は受注しました。開発中です。";

                case JobStatus.Delivery:
                    return "この仕事は納品しました。請求中です。";

                case JobStatus.Finished:
                    return "この仕事は全行程完了しました。";

                default:
                    return "";

            }

        }

    }

}
