using BlogMVVMSample.Data;
using System;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.Model
{

    /// <summary>
    /// Model
    /// </summary>
    public class ComboBoxModel
    {

        #region ViewModel.Property

        /// <summary>
        /// 学生一覧
        /// </summary>
        public ObservableCollection<Student> Students;

        /// <summary>
        /// 選択中の学生
        /// </summary>
        public Student SelectedStudent;

        #endregion

        /// <summary>
        /// Model
        /// </summary>
        public ComboBoxModel()
        {

            // 一覧に初期値を設定
            Students = new ObservableCollection<Student>
            {
                new Student(){ No = 1, Name = "Aさん", Birthday = new DateTime(2000, 4, 11) },
                new Student(){ No = 2, Name = "Bさん", Birthday = new DateTime(2000, 5, 4) },
                new Student(){ No = 3, Name = "Cさん", Birthday = new DateTime(2000, 6, 3) },
            };

            // 選択データの初期値を設定
            SelectedStudent = Students[0];

        }

    }

}
