using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class ComboBoxViewModel : ViewModelBase
    {

        #region Model

        /// <summary>
        /// Model
        /// </summary>
        private Model.ComboBoxModel _Model;

        #endregion

        #region Property

        /// <summary>
        /// 学生一覧
        /// </summary>
        public ObservableCollection<Student> Students
        {
            get { return _Model.Students; }
            set
            {

                _Model.Students = value;
                CallPropertyChanged();

            }
        }

        /// <summary>
        /// 選択中の学生
        /// </summary>
        public Student SelectedStudent
        {
            get { return _Model.SelectedStudent; }
            set
            {

                _Model.SelectedStudent = value;
                CallPropertyChanged();

            }
        }

        #endregion

        /// <summary>
        /// ViewModel
        /// </summary>
        public ComboBoxViewModel()
        {

            // Modelを新規作成
            _Model = new Model.ComboBoxModel();

        }

    }

}
