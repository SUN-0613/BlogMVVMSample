using System;

namespace BlogMVVMSample.Data
{

    /// <summary>
    /// 学生クラス
    /// </summary>
    public class Student
    {

        /// <summary>
        /// 出席番号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

    }

}
