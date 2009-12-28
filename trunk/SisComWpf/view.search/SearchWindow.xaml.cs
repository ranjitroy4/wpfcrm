using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SisComWpf.View.Search;
using SisComWpf.controller.search;
using SisComWpf.view.common;

namespace SisComWpf.view.search {
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window, IViewSearch {

        ICtrlSearchAction controller = new CtrlSelectSearch();
       
        public SearchWindow() {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e) {
            controller.DoAction(this);
        }

        public String WindowTitle {
            set { this.Title = value; }
            get { return this.Title; }
        }

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get { return this.ucSearch.BusinessObject; }
            set {
                this.ucSearch.BusinessObject = value;
                this.WindowTitle = value.ViewName;
            }
        }

        public object DataObject {
            get { return this.ucSearch.DataObject; }
            set { this.ucSearch.DataObject = value; }
        }

        public void Update(string sMessage, WarningMsgType msgType) {
            this.ucSearch.Update(sMessage, msgType);
        }

        #endregion

        #region IViewSearch Members

        public void SetSearchOptions(List<string> parameters) {
            this.ucSearch.SetSearchOptions(parameters);
        }

        public void GetSearchResult(IQueryable result) {
            this.ucSearch.GetSearchResult(result);
        }

        public SearchType SearchFor {
            get { return ucSearch.SearchFor; }
            set { this.ucSearch.SearchFor = value; }
        }

        #endregion
    }
}