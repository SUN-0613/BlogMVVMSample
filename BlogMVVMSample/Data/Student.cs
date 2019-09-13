using System;

namespace BlogMVVMSample.Data
{

    /// <summary>学生クラス</summary>
    public class Student
    {

        #region Property

        /// <summary>出席番号</summary>
        public int No { get; set; }

        /// <summary>名前</summary>
        public string Name { get; set; }

        /// <summary>生年月日</summary>
        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {

                // 値セット後、年齢を計算
                _Birthday = value;
                Age = CalcAge();

            }
        }

        /// <summary>
        /// 年齢
        /// </summary>
        public int Age { get; private set; }

        /// <summary>性別</summary>
        public GenderStatus Gender { get; set; }

        /// <summary>進路は就職か</summary>
        public bool IsWorkNext { get; set; }

        /// <summary>メールアドレス</summary>
        public string MailAddress { get; set; }

        #endregion

        /// <summary>生年月日</summary>
        private DateTime _Birthday;

        /// <summary>生年月日から年齢計算</summary>
        /// <returns>年齢</returns>
        private int CalcAge()
        {

            // 今年と生まれた年の差を求める
            int age = DateTime.Today.Year - Birthday.Year;

            // 今年の誕生日が過ぎてなければ1歳減らす
            if (new DateTime(DateTime.Today.Year, Birthday.Month, Birthday.Day) > DateTime.Today)
            {
                age--;
            }

            return age;

        }

    }

}
