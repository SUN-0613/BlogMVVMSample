namespace BlogMVVMSample.Forms.Model
{

    /// <summary>
    /// TextBox3.ViewModel
    /// </summary>
    public class TextBox3Model
    {

        #region ViewModel.Property

        /// <summary>
        /// 表示No
        /// </summary>
        public int[] Numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        #endregion

        /// <summary>
        /// 表示Noに指定値を加算
        /// </summary>
        /// <param name="addValue">指定値</param>
        public void AddNumbers(int addValue)
        {

            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] += addValue;
            }

        }

    }
}
