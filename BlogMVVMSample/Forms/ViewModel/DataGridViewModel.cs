using BlogMVVMSample.Data;
using System;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>DataGrid.ViewModel</summary>
    public class DataGridViewModel
    {

        #region Property

        /// <summary>学生一覧</summary>
        public ObservableCollection<Student> Students { get; set; }

        #endregion

        /// <summary>DataGrid.ViewModel</summary>
        public DataGridViewModel()
        {

            Students = new ObservableCollection<Student>()
            {
                new Student(){ No = 1, Name = "Aさん", Birthday = new DateTime(2000, 4, 11), Gender = GenderStatus.Male, IsWorkNext = true, MailAddress = "aaa@student.com" },
                new Student(){ No = 2, Name = "Bさん", Birthday = new DateTime(2000, 5, 4), Gender = GenderStatus.Female, IsWorkNext = false, MailAddress = "bbb@student.com" },
                new Student(){ No = 3, Name = "Cさん", Birthday = new DateTime(2000, 10, 10), Gender = GenderStatus.Other, IsWorkNext = false, MailAddress = "ccc@student.com" },
            };

        }

    }

}
