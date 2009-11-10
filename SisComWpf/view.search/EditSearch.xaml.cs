using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SisComWpf.view.common;
using System;

namespace SisComWpf.View.Search {
    /// <summary>
    /// Interaction logic for EditSearch.xaml
    /// </summary>
    public partial class EditSearch : UserControl, IViewSearch {
        
        public EditSearch() {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) {
                InitializeComponent();
                this.titleBar.CloseButton.Click += new RoutedEventHandler(btnClose_Click);
            }
        }

        public String WindowTitle {
            set { this.titleBar.Title = value; }
            get { return this.titleBar.Title; }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            // Implementar o controle aqui
            var iView = ViewFactory.BuildViewByEntitie(this.ucSearch.DataObject.GetType());
            iView.DataObject = this.ucSearch.DataObject;
            CommonView.CreateViewObject((Panel)this.Parent, iView, this.ucSearch.DataObject);
        }

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get { return this.ucSearch.BusinessObject;  }
            set { this.ucSearch.BusinessObject = value;
                  this.WindowTitle = value.ViewName;
            }
        }

        public object DataObject {
            get { return this.ucSearch.DataObject;  }
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
