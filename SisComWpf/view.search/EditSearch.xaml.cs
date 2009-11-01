using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SisComWpf.View.Search {
    /// <summary>
    /// Interaction logic for EditSearch.xaml
    /// </summary>
    public partial class EditSearch : UserControl, IViewSearch {
        public EditSearch() {
            InitializeComponent();
            this.titleBar.CloseButton.Click +=new RoutedEventHandler(btnClose_Click);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            var iView = ViewFactory.BuildViewByEntitie(this.ucSearch.DataObject.GetType());
            iView.DataObject = this.ucSearch.DataObject;
            CommonView.CreateViewObject((Panel)this.Parent, iView, this.ucSearch.DataObject);
        }

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get { return this.ucSearch.BusinessObject;  }
            set { this.ucSearch.BusinessObject = value; }
        }

        public object DataObject {
            get { return this.ucSearch.DataObject;  }
            set { this.ucSearch.DataObject = value; }
        }

        public void Update(string sMessage) {
            this.ucSearch.Update(sMessage);
        }

        #endregion

        #region IViewSearch Members

        public void SetSearchOptions(List<string> parameters) {
            this.ucSearch.SetSearchOptions(parameters);
        }

        public void GetSearchResult(IQueryable result) {
            this.ucSearch.GetSearchResult(result);
        }

        #endregion

        #region IViewSearch Members

        public SearchType SearchFor {
            get { return ucSearch.SearchFor; }
            set { this.ucSearch.SearchFor = value; }
        }

        #endregion
    }
}
