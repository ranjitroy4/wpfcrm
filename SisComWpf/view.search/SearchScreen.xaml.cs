using System;
using System.Windows;
using System.Windows.Controls;
using SisComWpf.Controller.Search;
using SisComWpf.Model;
using System.Linq;
using System.Collections.Generic;

namespace SisComWpf.View.Search {
    
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class SearchScreen : UserControl, IViewSearch {

        private object dataObject;
        private SearchType searchType;
        ICtrlSearch controller;

        public SearchScreen() {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SearchScreen_Loaded);
        }

        private void SearchScreen_Loaded(object sender, RoutedEventArgs e) {
            this.GetSearchOptions();
        }

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get { return controller; }
            set { controller = (ICtrlSearch) value; }
        }

        public object DataObject {
            get { return dataObject;  }
            set { dataObject = value; }
        }

        #endregion

        private void GetSearchOptions() {
            controller.OptionsToSearch();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            controller.DoSearch(cboSearch.SelectedValue.ToString(), txtSearch.Text);
        }

        private void dtgSearch_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            this.DataObject = dtgSearch.SelectedItem;
        }

        #region IViewSearch Members

        public void SetSearchOptions(List<String> list) {
            this.cboSearch.ItemsSource = list;
            cboSearch.SelectedIndex = 1;
        }

        public void GetSearchResult(IQueryable result) {
            this.dtgSearch.ItemsSource = result;
        }

        public void Update(string sMessage) {
            lblWarning.Text = sMessage;
        }

        #endregion



        #region IViewSearch Members


        public SearchType SearchFor {
            get {
                return searchType;
            }
            set {
                searchType = value;
            }
        }

        #endregion
    }
}