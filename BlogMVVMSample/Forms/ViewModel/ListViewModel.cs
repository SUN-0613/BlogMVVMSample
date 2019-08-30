﻿using BlogMVVMSample.Data;
using BlogMVVMSample.MVVM;
using System.Collections.ObjectModel;

namespace BlogMVVMSample.Forms.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    public class ListViewModel : ViewModelBase
    {

        #region Model

        private Model.ListModel _Model = new Model.ListModel();

        #endregion

        #region Property

        /// <summary>
        /// パス一覧
        /// </summary>
        public ObservableCollection<PathInfo> Paths
        {
            get { return _Model.Paths; }
            set { _Model.Paths = value; }
        }

        #endregion

    }
}